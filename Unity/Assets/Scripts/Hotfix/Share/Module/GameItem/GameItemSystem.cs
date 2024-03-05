namespace ET
{
    [EntitySystemOf(typeof(GameItem))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public static partial class GameItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameItem self, int config)
        {
            self.ItemConfig = config;
        }
    }
}