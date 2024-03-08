
namespace ET.Client
{
    [EntitySystemOf(typeof(MapleComponent))]
    [FriendOf(typeof(MapleComponent))]
    public static partial class MapleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MapleComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this MapleComponent self)
        {
            self.MapleInfo = null;
        }
        
        public static async ETTask PullServers(this MapleComponent self, string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                account = "1";
            }

            //account = "test1234";
#if UNITY_IOS
            var endUrl = $"?game_version={Application.version}&district_group=1&open_id={account}&platform=ios";
#elif UNITY_ANDROID
            var endUrl = $"?game_version={Application.version}&district_group=1&open_id={account}&platform=android";
#else
            var endUrl = $"?game_version=1.0.0&district_group=1&open_id={account}&platform=all";
#endif
            string mapUrl = $"http://172.16.10.104:27414/api/game/maple_info?game_version=1.0.0&open_id={account}&platform=all&district_group=1";
            if (string.IsNullOrEmpty(mapUrl))
            {
                return;
            }
            
            await self.GetServerList(mapUrl);
        }

        /// <summary>
        /// 获取服务器信息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="url"></param>
        public static async ETTask GetServerList(this MapleComponent self, string url)
        {
            string content = await HttpClientHelper.Get(url);

            if (string.IsNullOrEmpty(content))
            {
                Log.Debug("PullServers HttpGet content empty");
                return;
            }
            
            self.MapleInfo = MongoHelper.FromJson<MapleResponse>(content);
        }
    }
}

