namespace ET.Server
{
    [EntitySystemOf(typeof(TrapComponent))]
    [FriendOfAttribute(typeof(ET.Server.TrapComponent))]
    public static partial class TrapComponentSystem
    {
        [Invoke(TimerInvokeType.TrapTickTimer)]
        public class TrapTickTimer : ATimer<TrapComponent>
        {
            protected override void Run(TrapComponent self)
            {
                self.Tick();
            }
        }

        [Invoke(TimerInvokeType.TrapTotalTimer)]
        public class TrapTotalTimer : ATimer<TrapComponent>
        {
            protected override void Run(TrapComponent self)
            {
                self.Timeover();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.TrapComponent self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<ActionTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.TrapComponent self)
        {
            self.ConfigId = default;
            self.TickCount = default;
            self.Targets.Clear();
            self.OwnerId = default;

            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TotalTimer);
        }

        public static void Start(this TrapComponent self)
        {
            TrapConfig config = self.Config;

            if (config.TotalTime > 0)
            {
                long time = TimeInfo.Instance.ServerNow() + config.TotalTime;
                self.TickTimer = self.Root().GetComponent<TimerComponent>().NewOnceTimer(time, TimerInvokeType.TrapTickTimer, self);
            }

            if (config.Interval > 0)
            {
                self.TickTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(config.Interval, TimerInvokeType.TrapTickTimer, self);
            }
        }

        private static void Tick(this TrapComponent self)
        {
            Unit trap = self.GetParent<Unit>();
            TrapConfig config = self.Config;

            int err = SelectTargetHelper.Select(trap, config.SelectTargetType, config.SelectTargetsParam, ref self.Targets);
            if (err != ErrorCode.ERR_Success)
            {
                Log.Error($"陷阱选择目标失败，错误码：{err}");
                return;
            }

            if (self.Targets.Count < 1)
            {
                return;
            }
            
            self.TickCount++;

            if (config.IntervalActions.Count > 0)
            {
                foreach (int action in config.IntervalActions)
                {
                    self.Create(action, trap, trap, ActionTriggerType.TrapTick);
                }
            }

            if (config.TickLimit > 0 && config.TickLimit >= self.TickCount)
            {
                self.Timeover();
            }
        }

        private static void Timeover(this TrapComponent self)
        {
            Unit unit = self.GetOwner();
            if (unit == null || unit.IsDisposed)
            {
                self.DisposeInner();
                return;
            }

            Unit trap = self.GetParent<Unit>();

            TrapConfig config = self.Config;
            if (config.DestroyActions.Count > 0)
            {
                foreach (int action in config.DestroyActions)
                {
                    self.Create(action, trap, trap, ActionTriggerType.TrapDestroy);
                }
            }
            
            self.DisposeInner();
        }

        private static void DisposeInner(this TrapComponent self)
        {
            self.Scene().GetComponent<UnitComponent>().Remove(self.Parent.Id);
        }

        private static Unit GetOwner(this TrapComponent self)
        {
            return self.Scene().GetComponent<UnitComponent>().Get(self.OwnerId);
        }
    }
}