namespace ET.Server
{
    [EntitySystemOf(typeof(DungeonConsumeComponent))]
    [FriendOfAttribute(typeof(ET.Server.DungeonConsumeComponent))]
    public static partial class DungeonConsumeComponentSystem
    {
        [Invoke(TimerInvokeType.ConsumeRecoverTimer)]
        public class ConsumeRecoverTimer : ATimer<DungeonConsumeComponent>
        {
            protected override void Run(DungeonConsumeComponent self)
            {
                self.Update();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.DungeonConsumeComponent self)
        {
            self.Consume = self.ConsumeMax = GlobalDataConfigCategory.Instance.DungeonConsumeMax;
            self.ConsumeTimer = self.Scene().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.ConsumeRecoverTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DungeonConsumeComponent self)
        {
            self.Consume = default;
            self.ConsumeMax = default;
            self.ConsumeRecoverTime = default;

            self.Scene().GetComponent<TimerComponent>().Remove(ref self.ConsumeTimer);
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.DungeonConsumeComponent self)
        {
            self.ConsumeTimer = self.Scene().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.ConsumeRecoverTimer, self);
        }

        public static int Get(this DungeonConsumeComponent self)
        {
            return self.Consume;
        }

        /// <summary>
        /// 增加体力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="consume"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static int Inc(this DungeonConsumeComponent self, int consume, string reason)
        {
            if (consume < 1)
            {
                return ErrorCode.ERR_DecConsumeInvalid;
            }

            self.Consume += consume;

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 扣除体力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="consume"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public static int Dec(this DungeonConsumeComponent self, int consume, string reason)
        {
            if (consume < 1)
            {
                return ErrorCode.ERR_DecConsumeInvalid;
            }

            if (self.Consume < consume)
            {
                return ErrorCode.ERR_ConsumeNotEnough;
            }

            self.Consume -= consume;

            return ErrorCode.ERR_Success;
        }

        private static void Update(this ET.Server.DungeonConsumeComponent self)
        {
            if (self.Consume >= self.ConsumeMax)
            {
                return;
            }

            long now = TimeInfo.Instance.ServerNow();
            if (self.ConsumeRecoverTime < now)
            {
                return;
            }

            self.ConsumeRecoverTime = now + GlobalDataConfigCategory.Instance.DungeonConsumeRecoverInterval;

            self.Inc(GlobalDataConfigCategory.Instance.DungeonConsumeRecoverValue, "定时回复体力");
        }
    }
}