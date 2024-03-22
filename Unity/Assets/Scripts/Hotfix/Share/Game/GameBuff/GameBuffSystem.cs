namespace ET
{
    [EntitySystemOf(typeof(GameBuff))]
    [FriendOfAttribute(typeof(ET.GameBuff))]
    [FriendOfAttribute(typeof(ET.GameBuffContinueComponent))]
    public static partial class GameBuffSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuff self, int configId)
        {
            self.ConfigId = configId;
            self.RemainderTime = self.Config.ContinueTime;
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuff self)
        {
            self.ConfigId = 0;
        }

        public static void ResetRemainderTime(this GameBuff self)
        {
            self.RemainderTime = self.Config.ContinueTime;
        }

        public static GameBuffInfo ToMessage(this GameBuff self)
        {
            GameBuffInfo info = GameBuffInfo.Create();
            info.ConfigId = self.ConfigId;
            info.Time = self.GetComponent<GameBuffContinueComponent>().Time;

            return info;
        }
    }
}