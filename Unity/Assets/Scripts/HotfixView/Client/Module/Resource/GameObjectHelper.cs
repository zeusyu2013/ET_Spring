using System;
using UnityEngine;

namespace ET.Client
{
    public static class GameObjectHelper
    {
        public static T Get<T>(this GameObject gameObject, string key) where T : class
        {
            try
            {
                return gameObject.GetComponent<ReferenceCollector>().Get<T>(key);
            }
            catch (Exception e)
            {
                throw new Exception($"获取{gameObject.name}的ReferenceCollector key失败, key: {key}", e);
            }
        }

        public static T AddOrGetComponent<T>(this GameObject go) where T : MonoBehaviour
        {
            T t = go.GetComponent<T>();
            if (t == null)
            {
                t = go.AddComponent<T>();
            }

            return t;
        }
    }
}