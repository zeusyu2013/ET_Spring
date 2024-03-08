using System;
using UnityEngine;
using UnityEngine.Networking;

namespace ET
{
    public static class CoroutineHelper
    {
        // 有了这个方法，就可以直接await Unity的AsyncOperation了
        public static async ETTask GetAwaiter(this AsyncOperation asyncOperation)
        {
            ETTask task = ETTask.Create(true);
            asyncOperation.completed += _ => { task.SetResult(); };
            await task;
        }
        
        public static async ETTask<(bool, string)> HttpGet(string url)
        {
            try
            {
                UnityWebRequest request = UnityWebRequest.Get(url);
                await request.SendWebRequest();
                
                if (request.result == UnityWebRequest.Result.ProtocolError || 
                    request.result == UnityWebRequest.Result.ConnectionError)
                {
                    return (false, request.error);
                }
                else
                {
                    return (true, request.downloadHandler.text);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"http request fail: {url.Substring(0,url.IndexOf('?'))}\n{e}");
            }
        }
    }
}