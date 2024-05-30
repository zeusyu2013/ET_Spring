using System;
using System.Collections.Generic;
using SimpleJSON;
using ThinkingData.Analytics;

namespace ET.Server
{
    [EntitySystemOf(typeof(ThinkingDataComponent))]
    [FriendOfAttribute(typeof(ET.Server.ThinkingDataComponent))]
    public static partial class ThinkingDataComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ThinkingDataComponent self, string directory)
        {
            TDLog.Enable = true;

            self.TDAnalytics = new(new TDLoggerConsumer(directory));
            //ta.SetDynamicPublicProperties(new );
            self.TDAnalytics.SetPublicProperties(new Dictionary<string, object>()
            {
                { "PublicProperty", DateTime.Now },
                { "name", "PublicProperty" }
            });
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.ThinkingDataComponent self)
        {
            self.TDAnalytics = null;
        }

        public static void UserSet(this ThinkingDataComponent self, string accountId, string distinctId, string propertiesJson)
        {
            self.TDAnalytics.UserSet(accountId, distinctId, ToMap(propertiesJson));
        }

        public static void UserSetOnce(this ThinkingDataComponent self, string accountId, string distinctId, string propertiesJson)
        {
            self.TDAnalytics.UserSetOnce(accountId, distinctId, ToMap(propertiesJson));
        }

        public static void UserAdd(this ThinkingDataComponent self, string accountId, string distinctId, string propertiesJson)
        {
            self.TDAnalytics.UserAdd(accountId, distinctId, ToMap(propertiesJson));
        }

        public static void Track(this ThinkingDataComponent self, string accountId, string distinctId, string eventName, string propertiesJson)
        {
            self.TDAnalytics.Track(accountId, distinctId, eventName, ToMap(propertiesJson));
        }

        public static Dictionary<string, object> ToMap(string json)
        {
            Dictionary<string, object> properties = new();

            JSONNode node = JSON.Parse(json);
            foreach ((string key, JSONNode value) in node)
            {
                switch (value.Tag)
                {
                    case JSONNodeType.Array:
                        properties.Add(key, value.AsArray);
                        break;
                    case JSONNodeType.Object:
                        properties.Add(key, value.AsObject);
                        break;
                    case JSONNodeType.String:
                        properties.Add(key, value.Value);
                        break;
                    case JSONNodeType.Number:
                        properties.Add(key, value.AsFloat);
                        break;
                    case JSONNodeType.Boolean:
                        properties.Add(key, value.AsBool);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return properties;
        }
    }
}