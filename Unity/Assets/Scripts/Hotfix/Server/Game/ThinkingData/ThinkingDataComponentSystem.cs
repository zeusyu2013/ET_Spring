using System;
using System.Collections.Generic;
using ThinkingDataServer.Analytics;

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
            Dictionary<string, object> properties = LitJson.JsonMapper.ToObject<Dictionary<string, object>>(propertiesJson);
            self.TDAnalytics.UserSet(accountId, distinctId, properties);
        }

        public static void UserSetOnce(this ThinkingDataComponent self, string accountId, string distinctId, string propertiesJson)
        {
            Dictionary<string, object> properties = LitJson.JsonMapper.ToObject<Dictionary<string, object>>(propertiesJson);
            self.TDAnalytics.UserSetOnce(accountId, distinctId, properties);
        }

        public static void UserAdd(this ThinkingDataComponent self, string accountId, string distinctId, string propertiesJson)
        {
            Dictionary<string, object> properties = LitJson.JsonMapper.ToObject<Dictionary<string, object>>(propertiesJson);
            self.TDAnalytics.UserAdd(accountId, distinctId, properties);
        }

        public static void Track(this ThinkingDataComponent self, string accountId, string distinctId, string eventName, string propertiesJson)
        {
            Dictionary<string, object> properties = LitJson.JsonMapper.ToObject<Dictionary<string, object>>(propertiesJson);
            self.TDAnalytics.Track(accountId, distinctId, eventName, properties);
        }
    }
}