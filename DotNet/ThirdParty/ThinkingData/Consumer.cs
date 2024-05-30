using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Timers;
using Newtonsoft.Json.Converters;
using Timer = System.Timers.Timer;
using System.Net.Http;

namespace ThinkingData.Analytics
{
    /// <summary>
    /// Consumer interface
    /// </summary>
    public interface ITDConsumer
    {
        void Send(Dictionary<string, object> message);

        void Flush();

        void Close();

        /// <summary>
        /// enable local check or not
        /// </summary>
        /// <returns>true: enable check</returns>
        bool IsStrict();
    }

    /// <summary>
    /// Write data to file
    /// </summary>
    public class TDLoggerConsumer : ITDConsumer
    {
        protected const string DefaultFileNamePrefix = "log";
        protected const int DefaultBufferSize = 8192;
        protected const int DefaultBatchSec = 10;
        protected const int DefaultFileSize = -1;
        protected const RotateMode DefaultRotateMode = RotateMode.DAILY;
        protected const bool DefaultAsync = false;

        private readonly IsoDateTimeConverter _timeConverter = new IsoDateTimeConverter
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff"
        };

        private readonly string _logDirectory;
        private readonly int _bufferSize;
        private readonly int _batchSec;
        private readonly int _fileSize;
        private readonly string _fileNamePrefix;
        private readonly bool _async;
        private readonly RotateMode _rotateHourly;

        private readonly Timer _timer;
        private long _lastSendTime = -1;
        private readonly StringBuilder _messageBuffer;
        private InnerLoggerFileWriter _fileWriter;

        /// <summary>
        /// log file rotate type
        /// </summary>
        public enum RotateMode
        {
            /// <summary>
            /// rotate by the day
            /// </summary>
            DAILY,

            /// <summary>
            /// rotate by the hour
            /// </summary>
            HOURLY
        }

        /// <summary>
        /// init log consumer
        /// </summary>
        /// <param name="logDirectory">log file path</param>
        public TDLoggerConsumer(string logDirectory) : this(logDirectory, DefaultRotateMode, DefaultFileSize,
            DefaultFileNamePrefix, DefaultBufferSize, DefaultBatchSec, DefaultAsync)
        {
        }

        /// <summary>
        /// init log consumer
        /// </summary>
        /// <param name="logDirectory">log file path</param>
        /// <param name="config">config</param>
        public TDLoggerConsumer(string logDirectory, TDConfig config) : this(logDirectory, config.RotateMode,
            config.FileSize, config.FileNamePrefix, config.BufferSize, config.BatchSec, config.Async)
        {
        }

        protected TDLoggerConsumer(string logDirectory, RotateMode rotateHourly, int fileSize, string fileNamePrefix,
            int bufferSize, int batchSec, bool async)
        {
            TDLog.Log("Init consumer. Mode: TDLoggerConsumer, LogDirectory: {0}", logDirectory);

            _logDirectory = logDirectory + "/";
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }

            _rotateHourly = rotateHourly;
            _fileSize = fileSize;
            _fileNamePrefix = fileNamePrefix;
            _bufferSize = bufferSize;
            _async = async;
            _messageBuffer = new StringBuilder(bufferSize);
            if (!_async) return;
            _batchSec = batchSec * 1000;
            _timer = new Timer {Enabled = true, Interval = 1000};
            _timer.Start();
            _timer.Elapsed += Task;
            _lastSendTime = CurrentTimeMillis();
        }

        private void Task(object source, ElapsedEventArgs args)
        {
            if (CurrentTimeMillis() - _lastSendTime < _batchSec) return;
            try
            {
                Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static long CurrentTimeMillis()
        {
            return (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public virtual void Send(Dictionary<string, object> message)
        {
            lock (this)
            {
                try
                {
                    string jsonStr = JsonConvert.SerializeObject(message, _timeConverter);
                    _messageBuffer.Append(jsonStr);
                    _messageBuffer.Append("\r\n");
                    TDLog.Log("Enqueue to buffer: {0}", jsonStr);
                }
                catch (Exception e)
                {
                    throw new SystemException("Failed to add data", e);
                }

                if (_messageBuffer.Length >= _bufferSize)
                {
                    Flush();
                }
            }
        }

        public void Flush()
        {
            lock (this)
            {
                if (_messageBuffer.Length == 0)
                {
                    return;
                }

                TDLog.Log("Write to file, string.length = {0}", _messageBuffer.Length);

                var fileName = GetFileName();

                if (_fileWriter != null && !_fileWriter.IsValid(fileName))
                {
                    InnerLoggerFileWriter.RemoveInstance(_fileWriter);
                    _fileWriter = null;
                }

                if (_fileWriter == null)
                {
                    _fileWriter = InnerLoggerFileWriter.GetInstance(fileName);
                }

                if (!_fileWriter.Write(_messageBuffer)) return;
                _messageBuffer.Length = 0;
                _lastSendTime = CurrentTimeMillis();
            }
        }

        public string GetFileName()
        {
            var sdf = this._rotateHourly == RotateMode.HOURLY
                ? DateTime.Now.ToString("yyyy-MM-dd-HH")
                : DateTime.Now.ToString("yyyy-MM-dd");
            var fileBase = _logDirectory + _fileNamePrefix + "." + sdf + "_";
            var count = 0;
            var fileComplete = fileBase + count;
            var target = new FileInfo(fileComplete);
            if (_fileSize <= 0) return fileComplete;
            while (File.Exists(fileComplete) && FileSizeOut(target))
            {
                count += 1;
                fileComplete = fileBase + count;
                target = new FileInfo(fileComplete);
            }

            return fileComplete;
        }

        public bool FileSizeOut(FileInfo target)
        {
            var fsize = target.Length;
            fsize /= (1024 * 1024);
            return fsize >= _fileSize;
        }

        public void Close()
        {
            Flush();
            if (_fileWriter == null) return;
            InnerLoggerFileWriter.RemoveInstance(_fileWriter);
            _fileWriter = null;
        }

        public bool IsStrict()
        {
            return false;
        }

        /// <summary>
        /// TDLoggerConsumer's config
        /// </summary>
        public class TDConfig
        {
            public int BufferSize { get; set; } = 50;
            public int BatchSec { get; set; } = 10;
            public int FileSize { get; set; } = -1;
            public string FileNamePrefix { get; set; } = "log";
            public bool Async { get; set; } = true;
            public RotateMode RotateMode { get; set; } = RotateMode.DAILY;
        }

        /// <summary>
        /// [Deprecated] Please use TDLoggerConsumer.TDConfig
        /// </summary>
        [Obsolete("Please use TDLoggerConsumer.TDConfig")]
        public class LogConfig : TDConfig
        {

        }

        private class InnerLoggerFileWriter
        {
            private static readonly Dictionary<string, InnerLoggerFileWriter> Instances =
                new Dictionary<string, InnerLoggerFileWriter>();

            private readonly string _fileName;
            private readonly Mutex _mutex;
            private readonly FileStream _outputStream;
            private int _refCount;

            private InnerLoggerFileWriter(string fileName)
            {
                _outputStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                _fileName = fileName;
                _refCount = 0;
                _mutex = new Mutex(false);
            }

            public static InnerLoggerFileWriter GetInstance(string fileName)
            {
                if (Instances.ContainsKey(fileName))
                {
                    return Instances[fileName];
                }

                lock (Instances)
                {
                    if (!Instances.ContainsKey(fileName))
                    {
                        Instances.Add(fileName, new InnerLoggerFileWriter(fileName));
                    }

                    var writer = Instances[fileName];
                    writer._refCount += 1;
                    return writer;
                }
            }

            public static void RemoveInstance(InnerLoggerFileWriter writer)
            {
                lock (Instances)
                {
                    writer._refCount -= 1;
                    if (writer._refCount != 0) return;
                    writer.Close();
                    Instances.Remove(writer._fileName);
                }
            }

            private void Close()
            {
                _outputStream.Close();
                _mutex.Close();
            }

            public bool IsValid(string fileName)
            {
                return this._fileName.Equals(fileName);
            }

            public bool Write(StringBuilder data)
            {
                bool lockToken = false;
                try
                {
                    _mutex.WaitOne();
                    lockToken = true;

                    var bytes = Encoding.UTF8.GetBytes(data.ToString());
                    _outputStream.Seek(0, SeekOrigin.End);
                    _outputStream.Write(bytes, 0, bytes.Length);
                    _outputStream.Flush();
                }
                finally
                {
                    if (lockToken)
                    {
                        _mutex.ReleaseMutex();
                    }
                }

                return true;
            }
        }
    }

    /// <summary>
    /// Report data by http
    /// </summary>
    public class TDBatchConsumer : ITDConsumer
    {
        protected const int MaxFlushBatchSize = 20;
        protected const int DefaultTimeOutSecond = 30;

        private readonly List<Dictionary<string, object>> _messageList;

        private readonly IsoDateTimeConverter _timeConverter = new IsoDateTimeConverter
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff"
        };

        private readonly string _url;
        private readonly string _appId;
        private readonly int _batchSize;
        private readonly int _requestTimeoutMillisecond;
        private readonly bool _throwException;
        private readonly bool _compress;
        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        public TDBatchConsumer(string serverUrl, string appId) : this(serverUrl, appId, MaxFlushBatchSize,
            DefaultTimeOutSecond, false, true)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="compress">http compress or not</param>
        public TDBatchConsumer(string serverUrl, string appId, bool compress) : this(serverUrl, appId, MaxFlushBatchSize,
            DefaultTimeOutSecond, false, compress)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="batchSize">flush event count each time</param>
        public TDBatchConsumer(string serverUrl, string appId, int batchSize) : this(serverUrl, appId, batchSize,
            DefaultTimeOutSecond)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="batchSize">flush event count each time</param>
        /// <param name="requestTimeoutSecond">http timeout</param>
        public TDBatchConsumer(string serverUrl, string appId, int batchSize, int requestTimeoutSecond) : this(serverUrl,
            appId, batchSize, requestTimeoutSecond, false)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        /// <param name="batchSize">flush event count each time</param>
        /// <param name="requestTimeoutSecond">http timeout</param>
        /// <param name="throwException">throw exception or not</param>
        /// <param name="compress">http compress or not</param>
        public TDBatchConsumer(string serverUrl, string appId, int batchSize, int requestTimeoutSecond,
            bool throwException, bool compress = true)
        {
            _messageList = new List<Dictionary<string, object>>();
            var relativeUri = new Uri("/sync_server", UriKind.Relative);
            _url = new Uri(new Uri(serverUrl), relativeUri).AbsoluteUri;
            this._appId = appId;
            this._batchSize = Math.Min(MaxFlushBatchSize, batchSize);
            this._throwException = throwException;
            this._compress = compress;
            this._requestTimeoutMillisecond = requestTimeoutSecond * 1000;

            _httpClient.Timeout = TimeSpan.FromMilliseconds(_requestTimeoutMillisecond);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("TA-Integration-Type", TDAnalytics.LibName);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("TA-Integration-Version", TDAnalytics.LibVersion);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", "C# SDK");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("version", TDAnalytics.LibVersion);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("appid", _appId);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("compress", _compress ? "gzip" : "none");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "text/plain");
        }

        public void Send(Dictionary<string, object> message)
        {
            lock (_messageList)
            {
                _messageList.Add(message);
                
                TDLog.Log("Enqueue to buffer.");

                if (_messageList.Count >= _batchSize)
                {
                    Flush();
                }
            }
        }

        public void Flush()
        {
            lock (_messageList)
            {
                while (_messageList.Count != 0)
                {
                    var batchRecordCount = Math.Min(_batchSize, _messageList.Count);
                    var batchList = _messageList.GetRange(0, batchRecordCount);
                    string sendingData;
                    try
                    {
                        sendingData = JsonConvert.SerializeObject(batchList, _timeConverter);
                    }
                    catch (Exception exception)
                    {
                        _messageList.RemoveRange(0, batchRecordCount);
                        if (_throwException)
                        {
                            throw new SystemException("Failed to serialize data.", exception);
                        }

                        continue;
                    }

                    try
                    {
                        SendToServer(sendingData);
                        _messageList.RemoveRange(0, batchRecordCount);
                    }
                    catch (Exception exception)
                    {
                        if (_throwException)
                        {
                            throw new SystemException("Failed to send message with BatchConsumer.", exception);
                        }

                        return;
                    }
                }
            }
        }

        private async void SendToServer(string dataStr)
        {
            try
            {
                TDLog.Log("Send data, request: {0}", dataStr);

                byte[] dataBytes = _compress ? Gzip(dataStr) : Encoding.UTF8.GetBytes(dataStr);

                var response = await _httpClient.PostAsync(_url, new ByteArrayContent(dataBytes));
                var responseString = await response.Content.ReadAsStringAsync();
                TDLog.Log("Send data, response: {0}", responseString);

                var resultJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new SystemException("C# SDK send response is not 200, content: " + responseString);
                }

                int code = Convert.ToInt32(resultJson["code"]);

                if (code != 0)
                {
                    if (code == -1)
                    {
                        if (this._throwException)
                        {
                            throw new SystemException("error msg:" +
                                                  (resultJson.ContainsKey("msg")
                                                      ? resultJson["msg"]
                                                      : "invalid data format"));
                        }
                    }
                    else if (code == -2)
                    {
                        if (this._throwException)
                        {
                            throw new SystemException("error msg:" +
                                                  (resultJson.ContainsKey("msg")
                                                      ? resultJson["msg"]
                                                      : "APP ID doesn't exist"));
                        }
                    }
                    else if (code == -3)
                    {
                        if (this._throwException)
                        {
                            throw new SystemException("error msg:" +
                                                  (resultJson.ContainsKey("msg")
                                                      ? resultJson["msg"]
                                                      : "invalid ip transmission"));
                        }
                    }
                    else
                    {
                        if (this._throwException)
                        {
                            throw new SystemException("Unexpected response return code: " + code);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                TDLog.Log(e + "\n  Cannot post message to " + _url);
            }
        }

        private static byte[] Gzip(string inputStr)
        {
            var inputBytes = Encoding.UTF8.GetBytes(inputStr);
            using (var outputStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    gzipStream.Write(inputBytes, 0, inputBytes.Length);
                return outputStream.ToArray();
            }
        }

        public void Close()
        {
            Flush();
        }

        public bool IsStrict()
        {
            return false;
        }
    }

    /// <summary>
    /// The data is reported one by one, and when an error occurs, the exception will be throwed
    /// </summary>
    public class TDDebugConsumer : ITDConsumer
    {
        private readonly string _url;
        private readonly string _appId;
        private readonly int _requestTimeout;
        private readonly bool _writeData;
        private readonly string _deviceId;
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly IsoDateTimeConverter _timeConverter = new IsoDateTimeConverter
            {DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff"};

        /// <summary>
        /// Init debug consumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        public TDDebugConsumer(string serverUrl, string appId) : this(serverUrl, appId, 30000)
        {
        }

        /// <summary>
        /// Init debug consumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        /// <param name="writeData">report data to TE or not</param>
        public TDDebugConsumer(string serverUrl, string appId, bool writeData) : this(serverUrl, appId, 30000, null, writeData)
        {
        }

        /// <summary>
        /// Init debug consumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        /// <param name="writeData">report data to TE or not</param>
        /// <param name="deviceId">debug device id</param>
        public TDDebugConsumer(string serverUrl, string appId, bool writeData, string deviceId) : this(serverUrl, appId, 30000, deviceId, writeData) 
        { 
        }

        /// <summary>
        /// Init debug consumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        /// <param name="requestTimeout">http timeout</param>
        /// <param name="writeData">report data to TE or not</param>
        public TDDebugConsumer(string serverUrl, string appId, int requestTimeout, bool writeData = true): this(serverUrl, appId, requestTimeout, null, writeData)
        {
        }

        /// <summary>
        /// Init debug consumer
        /// </summary>
        /// <param name="serverUrl">server url</param>
        /// <param name="appId">app id</param>
        /// <param name="requestTimeout">http timeout</param>
        /// <param name="deviceId">debug device id</param>
        /// <param name="writeData">report data to TE or not</param>
        public TDDebugConsumer(string serverUrl, string appId, int requestTimeout, string deviceId, bool writeData = true)
        {
            TDLog.Log("Init debug consumer. ServerUrl: {0}, appId: {1}, deviceID: {2}", serverUrl, appId, deviceId);

            var relativeUri = new Uri("/data_debug", UriKind.Relative);
            _url = new Uri(new Uri(serverUrl), relativeUri).AbsoluteUri;
            this._appId = appId;
            this._requestTimeout = requestTimeout;
            this._writeData = writeData;
            this._deviceId = deviceId;
            TDLog.Enable = true;

            _httpClient.Timeout = TimeSpan.FromMilliseconds(_requestTimeout);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
        }

        public void Send(Dictionary<string, object> message)
        {
            try
            {
                var sendingData = JsonConvert.SerializeObject(message, _timeConverter);
                TDLog.Log("Send data, request: {0}", sendingData);
                SendToServer(sendingData);
            }
            catch (Exception exception)
            {
                throw new SystemException("Failed to send message with DebugConsumer.", exception);
            }
        }

        private async void SendToServer(string dataStr)
        {
            try
            {
                List<KeyValuePair<string, string>> paramsList = new List<KeyValuePair<string, string>>() {
                    new KeyValuePair<string, string>("appid", _appId),
                    new KeyValuePair<string, string>("source", "server"),
                    new KeyValuePair<string, string>("dryRun", (_writeData ? 0 : 1).ToString()),
                    new KeyValuePair<string, string>("data", dataStr),
                };

                if (_deviceId != null)
                {
                    paramsList.Add(new KeyValuePair<string, string>("deviceId", _deviceId));
                }

                var response = await _httpClient.PostAsync(_url, new FormUrlEncodedContent(paramsList));
                var responseString = await response.Content.ReadAsStringAsync();

                TDLog.Log("Send data, response: {0}", responseString);

                var resultJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);
                var errorLevel = Convert.ToInt32(resultJson["errorLevel"]);
                if (errorLevel != 0)
                {
                    throw new Exception("\n Can't send because :\n" + responseString);
                }
            }
            catch (Exception e)
            {
                throw new SystemException(e + "\n Cannot post message to " + this._url);
            }
        }

        public void Flush()
        {
        }

        public void Close()
        {
        }

        public bool IsStrict()
        {
            return true;
        }
    }

    /// <summary>
    /// Log module
    /// </summary>
    public class TDLog
    {
        public static bool Enable { get; set; }

        public static void Log(string format, params object[] args)
        {
            if (Enable)
            {
                string prefix = string.Format("[ThinkingData][{0}] ", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                if (args != null)
                {
                    Console.WriteLine(prefix + format, args);
                }
                else
                {
                    Console.WriteLine(prefix + format, null, null);
                }
            }
        }
    }

    /// <summary>
    /// [Deprecated] Please use ITDConsumer
    /// </summary>
    [Obsolete("Please use ITDConsumer", false)]
    public interface IConsumer : ITDConsumer
    {

    }

    /// <summary>
    /// [Deprecated] Please use TDBatchConsumer
    /// </summary>
    [Obsolete("Please use TDBatchConsumer", false)]
    public class BatchConsumer : TDBatchConsumer
    {
        public BatchConsumer(string serverUrl, string appId) : this(serverUrl, appId, MaxFlushBatchSize,
            DefaultTimeOutSecond, false, true)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="compress">date compress or not</param>
        public BatchConsumer(string serverUrl, string appId, bool compress) : this(serverUrl, appId, MaxFlushBatchSize,
            DefaultTimeOutSecond, false, compress)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="batchSize">flush event count each time</param>
        public BatchConsumer(string serverUrl, string appId, int batchSize) : this(serverUrl, appId, batchSize,
            DefaultTimeOutSecond)
        {
        }

        /// <summary>
        /// init BatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="batchSize">flush event count each time</param>
        /// <param name="requestTimeoutSecond">http timeout</param>
        public BatchConsumer(string serverUrl, string appId, int batchSize, int requestTimeoutSecond) : this(serverUrl,
            appId, batchSize, requestTimeoutSecond, false)
        {
        }

        public BatchConsumer(string serverUrl, string appId, int batchSize, int requestTimeoutSecond,
            bool throwException, bool compress = true) : base(serverUrl, appId, batchSize, requestTimeoutSecond, throwException, compress)
        { }
    }

    /// <summary>
    /// [Deprecated] Please use TDBatchConsumer
    /// </summary>
    [Obsolete("Please use TDBatchConsumer. TDBatchConsumer is async", false)]
    public class AsyncBatchConsumer : ITDConsumer
    {
        private const int MaxFlushBatchSize = 20;
        private const int DefaultTimeOutSecond = 30;
        private TDBatchConsumer _consumer;

        public AsyncBatchConsumer(string serverUrl, string appId) : this(serverUrl, appId, MaxFlushBatchSize,
            DefaultTimeOutSecond, false, true)
        {
        }

        /// <summary>
        /// init AsyncBatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="compress">data compress or not</param>
        public AsyncBatchConsumer(string serverUrl, string appId, bool compress) : this(serverUrl, appId, MaxFlushBatchSize,
            DefaultTimeOutSecond, false, compress)
        {
        }

        /// <summary>
        /// init AsyncBatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="batchSize">flush event count each time</param>
        public AsyncBatchConsumer(string serverUrl, string appId, int batchSize) : this(serverUrl, appId, batchSize,
            DefaultTimeOutSecond)
        {
        }

        /// <summary>
        /// init AsyncBatchConsumer
        /// </summary>
        /// <param name="serverUrl">serverUrl</param>
        /// <param name="appId">appId</param>
        /// <param name="batchSize">flush event count each time</param>
        /// <param name="requestTimeoutSecond">http timeout</param>
        public AsyncBatchConsumer(string serverUrl, string appId, int batchSize, int requestTimeoutSecond) : this(serverUrl,
            appId, batchSize, requestTimeoutSecond, false)
        {
        }

        public AsyncBatchConsumer(string serverUrl, string appId, int batchSize, int requestTimeoutSecond,
            bool throwException, bool compress = true)
        {
            this._consumer = new TDBatchConsumer(serverUrl, appId, batchSize, requestTimeoutSecond, throwException, compress);
        }

        public void Send(Dictionary<string, object> message)
        {
            _consumer.Send(message);
        }

        public void Flush()
        {
            _consumer.Flush();
        }

        public void Close()
        {
            _consumer.Close();
        }

        public bool IsStrict()
        {
            return false;
        }
    }

    /// <summary>
    /// [Deprecated] Please use TDDebugConsumer
    /// </summary>
    [Obsolete("Please use TDDebugConsumer", false)]
    public class DebugConsumer : TDDebugConsumer
    {
        public DebugConsumer(string serverUrl, string appId) : this(serverUrl, appId, 30000)
        {
        }

        public DebugConsumer(string serverUrl, string appId, bool writeData) : this(serverUrl, appId, 30000, null, writeData)
        {
        }

        public DebugConsumer(string serverUrl, string appId, bool writeData, string deviceId) : this(serverUrl, appId, 30000, deviceId, writeData)
        {
        }

        public DebugConsumer(string serverUrl, string appId, int requestTimeout, bool writeData = true) : this(serverUrl, appId, requestTimeout, null, writeData)
        {
        }

        public DebugConsumer(string serverUrl, string appId, int requestTimeout, string deviceId, bool writeData = true) : 
            base(serverUrl, appId, requestTimeout, deviceId, writeData)
        {
        }
    }

    /// <summary>
    /// [Deprecated] Please use TDLoggerConsumer
    /// </summary>
    public class LoggerConsumer : TDLoggerConsumer
    {
        public LoggerConsumer(string logDirectory) : this(logDirectory, DefaultRotateMode, DefaultFileSize,
            DefaultFileNamePrefix, DefaultBufferSize, DefaultBatchSec, DefaultAsync)
        {
        }

        public LoggerConsumer(string logDirectory, int bufferSize, int batchSec) : this(logDirectory, DefaultRotateMode,
            DefaultFileSize, DefaultFileNamePrefix, bufferSize, batchSec, DefaultAsync)
        {
        }

        public LoggerConsumer(string logDirectory, bool async) : this(logDirectory, DefaultRotateMode, DefaultFileSize,
            DefaultFileNamePrefix, DefaultBufferSize, DefaultBatchSec, async)
        {
        }

        public LoggerConsumer(string logDirectory, TDConfig config) : this(logDirectory, config.RotateMode,
            config.FileSize, config.FileNamePrefix, config.BufferSize, config.BatchSec, config.Async)
        {
        }

        public LoggerConsumer(string logDirectory, int fileSize) : this(logDirectory, DefaultRotateMode, fileSize,
            DefaultFileNamePrefix, DefaultBufferSize, DefaultBatchSec, DefaultAsync)
        {
        }

        public LoggerConsumer(string logDirectory, string fileNamePrefix) : this(logDirectory, DefaultRotateMode,
            DefaultFileSize, fileNamePrefix, DefaultBufferSize, DefaultBatchSec, DefaultAsync)
        {
        }

        public LoggerConsumer(string logDirectory, RotateMode rotateHourly) : this(logDirectory, rotateHourly,
            DefaultFileSize, DefaultFileNamePrefix, DefaultBufferSize, DefaultBatchSec, DefaultAsync)
        {
        }

        public LoggerConsumer(string logDirectory, RotateMode rotateHourly, int fileSize, string fileNamePrefix, int bufferSize, int batchSec, bool async)
            : base(logDirectory, rotateHourly, fileSize, fileNamePrefix, bufferSize, batchSec, async)
        {
        }
    }
}