namespace ET
{
    [EntitySystemOf(typeof(GameBuffCounter))]
    [FriendOfAttribute(typeof(ET.GameBuffCounter))]
    public static partial class GameBuffCounterSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuffCounter self, int count)
        {
            self.Count = count;
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuffCounter self)
        {
            self.Count = 0;
        }
    }
}