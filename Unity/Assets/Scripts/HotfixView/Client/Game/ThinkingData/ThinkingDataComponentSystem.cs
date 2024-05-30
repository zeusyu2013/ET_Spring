using System;
using System.Collections.Generic;
using LitJson;
using ThinkingData.Analytics;

namespace ET.Client
{
    [EntitySystemOf(typeof(ThinkingDataComponent))]
    public static partial class ThinkingDataComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ThinkingDataComponent self, string appId, string serverUrl)
        {
            TDAnalytics.Init(appId, serverUrl);
            TDAnalytics.EnableAutoTrack(TDAutoTrackEventType.AppInstall | TDAutoTrackEventType.AppCrash);
        }

        [EntitySystem]
        private static void Destroy(this ThinkingDataComponent self)
        {
        }

        public static void SetSuperProperties(this ThinkingDataComponent self, Dictionary<string, object> properties)
        {
            TDAnalytics.SetSuperProperties(properties);
        }

        public static void UserSet(this ThinkingDataComponent self, string propertiesJson)
        {
            TDAnalytics.UserSet(ToMap(propertiesJson));
        }

        public static void UserSetOnce(this ThinkingDataComponent self, string propertiesJson)
        {
            TDAnalytics.UserSetOnce(ToMap(propertiesJson));
        }

        public static void UserAdd(this ThinkingDataComponent self, string propertiesJson)
        {
            TDAnalytics.UserAdd(ToMap(propertiesJson));
        }

        public static void Track(this ThinkingDataComponent self, string eventName, string propertiesJson)
        {
            TDAnalytics.Track(eventName, ToMap(propertiesJson));
        }

        public static Dictionary<string, object> ToMap(string json)
        {
            Dictionary<string, object> properties = new();
            if (string.IsNullOrEmpty(json))
            {
                return properties;
            }

            JsonData jsonData = JsonMapper.ToObject(json);

            foreach (string key in jsonData.Keys)
            {
                JsonData data = jsonData[key];
                switch (data.GetJsonType())
                {
                    case JsonType.None:
                        break;
                    case JsonType.Object:
                        break;
                    case JsonType.Array:
                        break;
                    case JsonType.String:
                        properties.Add(key, data.ToString());
                        break;
                    case JsonType.Int:
                        properties.Add(key, int.Parse(data.ToString()));
                        break;
                    case JsonType.Long:
                        properties.Add(key, long.Parse(data.ToString()));
                        break;
                    case JsonType.Double:
                        properties.Add(key, double.Parse(data.ToString()));
                        break;
                    case JsonType.Boolean:
                        properties.Add(key, data.ToString().ToLower() == "true");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return properties;
        }
    }
}