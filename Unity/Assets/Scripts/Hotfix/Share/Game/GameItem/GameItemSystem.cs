namespace ET.Server
{
    [EntitySystemOf(typeof(GameItem))]
    [FriendOfAttribute(typeof(GameItem))]
    public static partial class GameItemSystem
    {
        [EntitySystem]
        private static void Awake(this GameItem self, int config)
        {
            self.ConfigId = config;
        }

        [EntitySystem]
        private static void Destroy(this GameItem self)
        {
            self.ConfigId = 0;
            self.Amount = 0;
        }

        public static GameItemInfo ToMessage(this GameItem self)
        {
            GameItemInfo info = GameItemInfo.Create();
            info.Config = self.ConfigId;
            info.Amount = self.Amount;
            return info;
        }
    }
}