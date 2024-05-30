using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

///
/// \mainpage
/// # ThinkingData SDK for C# server
/// 
/// <img src="https://user-images.githubusercontent.com/53337625/205621683-ed9b97ef-6a52-4903-a2c0-a955dddebb7d.png" alt="logo" width="50%"/>
/// 
/// This is the[ThinkingData](https://www.thinkingdata.cn)™ SDK for C-Shap. Documentation is available on our help center in the following languages:
/// 
/// - [English](https://docs.thinkingdata.cn/ta-manual/latest/en/installation/installation_menu/server_sdk/csharp_sdk_installation/csharp_sdk_installation.html)
/// - [中文](https://docs.thinkingdata.cn/ta-manual/latest/installation/installation_menu/server_sdk/cshap_sdk_installation/cshap_sdk_installation.html)
/// - [日本語](https://docs.thinkingdata.cn/ta-manual/latest/ja/installation/installation_menu/server_sdk/csharp_sdk_installation/csharp_sdk_installation.html)
/// 
/// ---



namespace ThinkingData.Analytics
{

    /// <summary>
    /// dynamic common properties interface
    /// </summary>
    public interface ITDDynamicPublicProperties
    {
        Dictionary<string, object> GetDynamicPublicProperties();
    }

    /// <summary>
    /// Entry of SDK
    /// </summary>
    public class TDAnalytics
    {
        public const string LibVersion = "2.0.1";
        public const string LibName = "tga_csharp_sdk";

        private static readonly Regex KeyPattern =
            new Regex("^(#[a-z][a-z0-9_]{0,49})|([a-z][a-z0-9_]{0,50})$", RegexOptions.IgnoreCase);

        private readonly ITDConsumer _consumer;

        private readonly bool _enableUuid;

        private readonly Dictionary<string, object> _pubicProperties;

        private ITDDynamicPublicProperties _dynamicPublicProperties;


        /// <summary>
        /// init SDK with consumer
        /// </summary>
        /// <param name="consumer">data consumer</param>
        public TDAnalytics(ITDConsumer consumer) : this(consumer, false)
        {
        }

        /// <summary>
        /// init SDK with consumer
        /// </summary>
        /// <param name="consumer">data consumer</param>
        /// <param name="enableUuid">enable uuid</param>
        public TDAnalytics(ITDConsumer consumer, bool enableUuid)
        {
            TDLog.Log("Init SDK");
            _consumer = consumer;
            _enableUuid = enableUuid;
            _pubicProperties = new Dictionary<string, object>();
            ClearPublicProperties();
        }

        /// <summary>
        /// set public properties
        /// </summary>
        /// <param name="properties">custom public properties</param>
        public void SetPublicProperties(Dictionary<string, object> properties)
        {
            lock (_pubicProperties)
            {
                foreach (var kvp in properties)
                {
                    _pubicProperties[kvp.Key] = kvp.Value;
                }
            }
        }

        /// <summary>
        /// clear public properties
        /// </summary>
        public void ClearPublicProperties()
        {
            lock (_pubicProperties)
            {
                _pubicProperties.Clear();
                _pubicProperties.Add("#lib", LibName);
                _pubicProperties.Add("#lib_version", LibVersion);
            }
        }

        /// <summary>
        /// set dynamic public properties
        /// </summary>
        /// <param name="dynamicPublicProperties">object which implements ITDDynamicPublicProperties</param>
        public void SetDynamicPublicProperties(ITDDynamicPublicProperties dynamicPublicProperties)
        {
            _dynamicPublicProperties = dynamicPublicProperties;
        }

        /// <summary>
        /// report ordinary event
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="event_name">event name</param>
        public void Track(string account_id, string distinct_id, string event_name)
        {
            Add(account_id, distinct_id, "track", event_name, null, null);
        }

        /// <summary>
        /// report ordinary event
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="event_name">event name</param>
        /// <param name="properties">properties</param>
        /// <exception cref="SystemException">SystemException</exception>
        public void Track(string account_id, string distinct_id, string event_name, Dictionary<string, object> properties)
        {
            if (string.IsNullOrEmpty(event_name))
            {
                throw new SystemException("The event name must be provided.");
            }

            Add(account_id, distinct_id, "track", event_name, null, properties);
        }

        /// <summary>
        /// report first event
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="event_name">event name</param>
        /// <param name="first_check_id">it is flag of the first event</param>
        /// <param name="properties">properties</param>
        /// <exception cref="SystemException">SystemException</exception>
        public void TrackFirst(string account_id, string distinct_id, string event_name, string first_check_id, Dictionary<string, object> properties)
        {
            if (string.IsNullOrEmpty(event_name))
            {
                throw new SystemException("The event name must be provided.");
            }

            if (string.IsNullOrEmpty(first_check_id))
            {
                throw new SystemException("The first check id must be provided.");
            }

            Add(account_id, distinct_id, "track_first", event_name, first_check_id, properties);
        }

        /// <summary>
        /// report updatable event
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="event_name">event name</param>
        /// <param name="event_id">event id</param>
        /// <param name="properties">properties</param>
        /// <exception cref="SystemException">SystemException</exception>
        public void TrackUpdate(string account_id, string distinct_id, string event_name, string event_id, Dictionary<string, object> properties)
        {
            if (string.IsNullOrEmpty(event_name))
            {
                throw new SystemException("The event name must be provided.");
            }

            if (string.IsNullOrEmpty(event_id))
            {
                throw new SystemException("The event id must be provided.");
            }

            Add(account_id, distinct_id, "track_update", event_name, event_id, properties);
        }

        /// <summary>
        /// report overridable event
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="event_name">event name</param>
        /// <param name="event_id">event id</param>
        /// <param name="properties">properties</param>
        /// <exception cref="SystemException">SystemException</exception>
        public void TrackOverwrite(string account_id, string distinct_id, string event_name, string event_id, Dictionary<string, object> properties)
        {
            if (string.IsNullOrEmpty(event_name))
            {
                throw new SystemException("The event name must be provided.");
            }

            if (string.IsNullOrEmpty(event_id))
            {
                throw new SystemException("The event id must be provided.");
            }

            Add(account_id, distinct_id, "track_overwrite", event_name, event_id, properties);
        }

        /// <summary>
        /// set user properties. would overwrite existing names
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="properties">properties</param>
        public void UserSet(string account_id, string distinct_id, Dictionary<string, object> properties)
        {
            Add(account_id, distinct_id, "user_set", properties);
        }

        /// <summary>
        /// clear the user properties of users
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="properties">propertie keys list</param>
        public void UserUnSet(string account_id, string distinct_id, List<string> properties)
        {
            var props = properties.ToDictionary<string, string, object>(property => property, property => 0);
            Add(account_id, distinct_id, "user_unset", props);
        }

        /// <summary>
        /// set user properties, If such property had been set before, this message would be ingored
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="properties">properties</param>
        public void UserSetOnce(string account_id, string distinct_id, Dictionary<string, object> properties)
        {
            Add(account_id, distinct_id, "user_setOnce", properties);
        }

        /// <summary>
        /// set user properties once, If such property had been set before, this message would be ingored
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="property">key</param>
        /// <param name="value">value</param>
        public void UserSetOnce(string account_id, string distinct_id, string property, object value)
        {
            var properties = new Dictionary<string, object> {{property, value}};
            Add(account_id, distinct_id, "user_setOnce", properties);
        }

        /// <summary>
        /// to accumulate operations against the property
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="properties">properties</param>
        public void UserAdd(string account_id, string distinct_id, Dictionary<string, object> properties)
        {
            Add(account_id, distinct_id, "user_add", properties);
        }

        /// <summary>
        /// to accumulate operations against the property
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="property">key</param>
        /// <param name="value">value</param>
        public void UserAdd(string account_id, string distinct_id, string property, long value)
        {
            var properties = new Dictionary<string, object> {{property, value}};
            Add(account_id, distinct_id, "user_add", properties);
        }

        /// <summary>
        /// to add user properties of array type
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="properties">properties</param>
        public void UserAppend(string account_id, string distinct_id, Dictionary<string, object> properties)
        {
            Add(account_id, distinct_id, "user_append", properties);
        }

        /// <summary>
        /// append user properties to array type by unique
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        /// <param name="properties">properties</param>
        public void UserUniqAppend(string account_id, string distinct_id, Dictionary<string, object> properties)
        {
            Add(account_id, distinct_id, "user_uniq_append", properties);
        }

        /// <summary>
        /// delete a user, This operation cannot be undone
        /// </summary>
        /// <param name="account_id">account id</param>
        /// <param name="distinct_id">distinct id</param>
        public void UserDelete(string account_id, string distinct_id)
        {
            Add(account_id, distinct_id, "user_del", new Dictionary<string, object>());
        }

        /// <summary>
        /// report data immediately
        /// </summary>
        public void Flush()
        {
            TDLog.Log("SDK flush data.");
            _consumer.Flush();
        }

        /// <summary>
        /// close and exit sdk
        /// </summary>
        public void Close()
        {
            _consumer.Close();
            TDLog.Log("SDK close.");
        }

        private static bool IsNumber(object value)
        {
            return (value is sbyte) || (value is short) || (value is int) || (value is long) || (value is byte)
                   || (value is ushort) || (value is uint) || (value is ulong) || (value is decimal) ||
                   (value is float) || (value is double);
        }

        private static bool IsDictionary(object obj) 
        {
            if (obj == null) return false;
            return (obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>));
        }

        private static void AssertProperties(string type, IDictionary<string, object> properties)
        {
            if (null == properties)
            {
                return;
            }

            foreach (var kvp in properties)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                if (null == value)
                {
                    continue;
                }

                if (KeyPattern.IsMatch(key))
                {
                    if (!IsNumber(value) && !(value is string) && !(value is DateTime) && !(value is bool) &&
                        !(value is IList) && !IsDictionary(kvp.Value))
                    {
                        throw new ArgumentException(
                            "The supported data type including: Number, String, Date, Boolean,List. Invalid property: {key}");
                    }

                    if (type == "user_add" && !IsNumber(value))
                    {
                        throw new ArgumentException("Only Number is allowed for user_add. Invalid property:" + key);
                    }
                }
                else
                {
                    throw new ArgumentException("The " + type + "'" + key + "' is invalid.");
                }
            }
        }

        private void Add(string account_id, string distinct_id, string type, IDictionary<string, object> properties)
        {
            Add(account_id, distinct_id, type, null, null, properties);
        }

        private void Add(string account_id, string distinct_id, string type, string event_name, string event_id,
            IDictionary<string, object> properties)
        {
            if (_consumer.IsStrict() && string.IsNullOrEmpty(account_id) && string.IsNullOrEmpty(distinct_id))
            {
                throw new SystemException("account_id or distinct_id must be provided. ");
            }

            var eventProperties = new Dictionary<string, object>(properties ?? new Dictionary<string, object>());
            if (type == "track" || type == "track_update" || type == "track_overwrite"  || type == "track_first")
            {
                if (_dynamicPublicProperties != null)
                {
                    
                    foreach (var kvp in _dynamicPublicProperties.GetDynamicPublicProperties())
                    {
                        if (!eventProperties.ContainsKey(kvp.Key))
                        {
                            eventProperties.Add(kvp.Key, kvp.Value);
                        }
                    }
                }

                if (_pubicProperties != null)
                {
                    lock (_pubicProperties)
                    {
                        foreach (var kvp in _pubicProperties)
                        {
                            if (!eventProperties.ContainsKey(kvp.Key))
                            {
                                eventProperties.Add(kvp.Key, kvp.Value);
                            }
                        }
                    }
                }

                if (type == "track_first")
                {
                    type = "track";
                    if (event_id != null)
                    {
                        eventProperties.Add("#first_check_id", event_id);
                        event_id = null;
                    }
                }
            }

            var evt = new Dictionary<string, object>();
            if (account_id != null)
            {
                evt.Add("#account_id", account_id);
            }

            if (distinct_id != null)
            {
                evt.Add("#distinct_id", distinct_id);
            }

            if (event_name != null)
            {
                evt.Add("#event_name", event_name);
            }

            if (event_id != null)
            {
                evt.Add("#event_id", event_id);
            }

            // #uuid v4 formater is only supported
            if (eventProperties.ContainsKey("#uuid"))
            {
                evt.Add("#uuid", eventProperties["#uuid"]);
                eventProperties.Remove("#uuid");
            }
            else if (_enableUuid)
            {
                evt.Add("#uuid", Guid.NewGuid().ToString("D"));
            }

            if (_consumer.IsStrict())
            {
                AssertProperties(type, eventProperties);
            }

            if (eventProperties.ContainsKey("#ip"))
            {
                evt.Add("#ip", eventProperties["#ip"]);
                eventProperties.Remove("#ip");
            }

            if (eventProperties.ContainsKey("#app_id"))
            {
                evt.Add("#app_id", eventProperties["#app_id"]);
                eventProperties.Remove("#app_id");
            }
          
            if (eventProperties.ContainsKey("#first_check_id"))
            {
                evt.Add("#first_check_id", eventProperties["#first_check_id"]);
                eventProperties.Remove("#first_check_id");
            }

            if (eventProperties.ContainsKey("#time"))
            {
                evt.Add("#time", eventProperties["#time"]);
                eventProperties.Remove("#time");
            }
            else
            {
                evt.Add("#time", DateTime.Now);
            }

            evt.Add("#type", type);
            evt.Add("properties", eventProperties);
            _consumer.Send(evt);
        }
    }

    /// <summary>
    /// [Deprecated] Please use ITDDynamicPublicProperties
    /// </summary>
    [Obsolete("Please use ITDDynamicPublicProperties", false)]
    public interface IDynamicPublicProperties : ITDDynamicPublicProperties
    {
        
    }

    /// <summary>
    /// [Deprecated] Please use TDAnalytics
    /// </summary>
    [Obsolete("Please use TDAnalytics", false)]
    public class ThinkingdataAnalytics : TDAnalytics
    {
        public ThinkingdataAnalytics(ITDConsumer consumer) : base(consumer) { }
        public ThinkingdataAnalytics(ITDConsumer consumer, bool enableUuid) : base(consumer, enableUuid) { }
    }

    /// <summary>
    /// [Deprecated] Please use TDLog
    /// </summary>
    [Obsolete("Please use TDLog", false)]
    public class TALogger : TDLog { }

}