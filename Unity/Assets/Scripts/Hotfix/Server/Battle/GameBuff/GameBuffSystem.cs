namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuff))]
    [FriendOfAttribute(typeof(GameBuff))]
    [FriendOfAttribute(typeof(GameBuffContinueComponent))]
    public static partial class GameBuffSystem
    {
        [Invoke(TimerInvokeType.BuffTimer)]
        public class BuffTimer : ATimer<GameBuff>
        {
            protected override void Run(GameBuff t)
            {
                t.Check();
            }
        }

        [EntitySystem]
        private static void Awake(this GameBuff self, int configId)
        {
            self.ConfigId = configId;
            self.StartTime = TimeInfo.Instance.ServerNow();

            self.Timer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(self.StartTime + self.Config.ContinueTime, TimerInvokeType.BuffTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this GameBuff self)
        {
            self.ConfigId = 0;
            self.RemainderTime = 0;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
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

        private static void Check(this GameBuff self)
        {
            self.Dispose();
        }
    }
}