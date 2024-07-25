namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffCounter))]
    [FriendOfAttribute(typeof(GameBuffCounter))]
    public static partial class GameBuffCounterSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffCounter self)
        {
            BuffDotParams buffDotParams = (BuffDotParams)self.GetParent<GameBuff>().Config.Parameters;

            self.Count = buffDotParams.Count;
        }

        [EntitySystem]
        private static void Destroy(this GameBuffCounter self)
        {
            self.Count = 0;
        }
    }
}