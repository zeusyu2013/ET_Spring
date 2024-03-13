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
        }
    }
}