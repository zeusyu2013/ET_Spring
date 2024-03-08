namespace ET.Client
{
    [EntitySystemOf(typeof(RemoteConfigComponent))]
    [FriendOfAttribute(typeof(ET.Client.RemoteConfigComponent))]
    public static partial class RemoteConfigComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.RemoteConfigComponent self)
        {
            
        }

        public static async ETTask GetRemoteConfig(this RemoteConfigComponent self)
        {
            string content = await HttpClientHelper.Get(ClientConstValue.RemoteConfigUrl);
            self.RemoteConfig = MongoHelper.FromJson<RemoteConfig>(content);
        }
    }
}