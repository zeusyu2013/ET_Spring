using System;
using System.Collections.Generic;
using Aliyun.OSS;
using Aliyun.OSS.Common;

namespace ET
{
    public static class AliyunOSSHelper
    {
        // OSS地址
        public const string EndPoint = "https://oss-cn-hangzhou.aliyuncs.com";

        public const string Region = "cn-hangzhou";

        private static OssClient OssClient;

        private static bool _init = false;

        public static void Initialization()
        {
            if (_init)
            {
                return;
            }

            // 从环境变量中获取访问凭证,请确保已设置环境变量OSS_ACCESS_KEY_ID和OSS_ACCESS_KEY_SECRET。
            string accessKeyId = Environment.GetEnvironmentVariable("OSS_ACCESS_KEY_ID");
            string accessKeySecret = Environment.GetEnvironmentVariable("OSS_ACCESS_KEY_SECRET");

            ClientConfiguration config = new();
            OssClient = new OssClient(EndPoint, accessKeyId, accessKeySecret, config);

            _init = true;
        }

        public static void Upload(string bucket, List<string> abFiles)
        {
            if (!_init)
            {
                Console.WriteLine($"OSS未初始化");
                return;
            }

            if (abFiles.Count < 1)
            {
                Console.WriteLine($"上传文件列表为空");
                return;
            }

            foreach (string abFile in abFiles)
            {
                OssClient.PutObject(bucket, abFile, abFile);
            }
        }
    }
}