using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(QualityComponent))]
    [FriendOfAttribute(typeof(ET.Client.QualityComponent))]
    public static partial class QualityComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.QualityComponent self)
        {
            
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.QualityComponent self)
        {
        }

        public static async ETTask LoadRemoteConfig(this QualityComponent self, string url)
        {
            string content = await HttpClientHelper.Get(url);
            self.QualityConfig = MongoHelper.FromJson<QualityConfig>(content);
            
            Log.Info("加载游戏画质分级配置完成");
        }

        public static void TestDevice(this QualityComponent self)
        {
            if (GlobalData.Instance.IsEditor)
            {
                self.QualityType = QualityType.Ultra;
            }
            else if (GlobalData.Instance.IsAndroid)
            {
            }
            else if (GlobalData.Instance.IsiPhone)
            {
            }

            self.ModifyGameQuality(self.QualityType);
        }

        public static void ModifyGameQuality(this QualityComponent self, QualityType type)
        {
            self.QualityType = type;

            // todo:修改各自定义品质
            // 0.unity quality setting
            self.ModifyUnityQuality(type);
        }

        private static void ModifyUnityQuality(this QualityComponent self, QualityType type)
        {
            int destination = -1;
            int currentQuality = QualitySettings.GetQualityLevel();
            for (int i = 0; i < QualitySettings.names.Length; i++)
            {
                if (QualitySettings.names[i] == "")
                {
                    destination = i;
                    break;
                }
            }

            if (destination == -1 || currentQuality == destination)
            {
                return;
            }

            QualitySettings.SetQualityLevel(destination);
        }
    }
}