namespace ET.Server
{
    [EntitySystemOf(typeof(BulletComponent))]
    [FriendOfAttribute(typeof(ET.Server.BulletComponent))]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public static partial class BulletComponentSystem
    {
        [Invoke(TimerInvokeType.BulletTickTimer)]
        public class BulletTickTimer : ATimer<BulletComponent>
        {
            protected override void Run(BulletComponent self)
            {
                self.Tick();
            }
        }

        [Invoke(TimerInvokeType.BulletTickTimer2)]
        public class BulletTickTimer2 : ATimer<BulletComponent>
        {
            protected override void Run(BulletComponent self)
            {
                self.Tick1();
            }
        }

        [Invoke(TimerInvokeType.BulletTickTimer3)]
        public class BulletTickTimer3 : ATimer<BulletComponent>
        {
            protected override void Run(BulletComponent self)
            {
                self.Tick2();
            }
        }

        [Invoke(TimerInvokeType.BulletTotalTimer)]
        public class BulletTimeover : ATimer<BulletComponent>
        {
            protected override void Run(BulletComponent self)
            {
                self.Timeover();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.BulletComponent self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<ActionTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BulletComponent self)
        {
            self.ConfigId = default;
            self.TickCount = default;
            self.OwnerId = default;

            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer2);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer3);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TotalTimer);
        }

        public static void Start(this BulletComponent self)
        {
            Unit owner = self.GetOwner();
            if (owner == null)
            {
                self.Dispose();
                return;
            }

            BulletConfig config = self.Config;
            if (config.CreateActions.Count > 0)
            {
                foreach (int createAction in config.CreateActions)
                {
                    self.Create(createAction, owner, owner, ActionTriggerType.BulletStart);
                }
            }

            if (config.Interval > 0)
            {
                int interval = config.Interval;
                if (interval <= 100)
                {
                    interval = 100;
                }

                self.TickTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(interval, TimerInvokeType.BulletTickTimer, self);
            }

            if (config.Tick1.Count > 0)
            {
                self.TickTimer2 = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(100, TimerInvokeType.BulletTickTimer2, self);
            }

            if (config.Tick2.Count > 0)
            {
                self.TickTimer3 = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.BulletTickTimer3, self);
            }

            if (config.TotalTime > 0)
            {
                self.TotalTimer = self.Root().GetComponent<TimerComponent>()
                        .NewRepeatedTimer(TimeInfo.Instance.ServerNow() + config.TotalTime, TimerInvokeType.BulletTotalTimer, self);
            }
        }

        public static void Tick(this BulletComponent self)
        {
            Unit bullet = self.GetParent<Unit>();
            Unit owner = self.GetOwner();
            if (owner == null)
            {
                self.Dispose();
                return;
            }

            BulletConfig config = self.Config;

            int err = SelectTargetHelper.Select(owner, config.SelectTargetType, config.SelectTargetsParam, ref self.Targets);
            if (err != ErrorCode.ERR_Success)
            {
                Log.Error($"子弹选择目标失败，错误码：{err}");
                return;
            }

            if (self.Targets.Count < 1)
            {
                return;
            }

            self.TickCount++;

            if (config.IntervalCasts.Count > 0)
            {
                foreach (int castConfigId in config.IntervalCasts)
                {
                    Cast cast = owner.Create(castConfigId);
                    cast.Targets.AddRange(self.Targets);
                    err = cast.Cast();
                    if (err != ErrorCode.ERR_Success)
                    {
                        Log.Error($"子弹 {self.ConfigId} 释放Cast {castConfigId} 失败，错误码：{err}");
                    }
                }
            }

            if (config.IntervalActions.Count > 0)
            {
                foreach (int action in config.IntervalActions)
                {
                    self.Create(action, bullet, bullet, ActionTriggerType.BulletTick);
                }
            }

            if (config.TickLimit > 0 && self.TickCount >= config.TickLimit)
            {
                self.Timeover();
            }
        }

        private static void Tick1(this BulletComponent self)
        {
            Unit owner = self.GetOwner();
            Unit bullet = self.GetParent<Unit>();
            
            BulletConfig config = self.Config;

            SelectTargetHelper.Select(owner, config.SelectTargetType, config.SelectTargetsParam, ref self.Targets);
            
            foreach (int action in config.Tick1)
            {
                self.Create(action, bullet, bullet, ActionTriggerType.BulletTick);
            }
        }

        private static void Tick2(this BulletComponent self)
        {
            Unit owner = self.GetOwner();
            Unit bullet = self.GetParent<Unit>();
            
            BulletConfig config = self.Config;

            SelectTargetHelper.Select(owner, config.SelectTargetType, config.SelectTargetsParam, ref self.Targets);
            
            foreach (int action in config.Tick2)
            {
                self.Create(action, bullet, bullet, ActionTriggerType.BulletTick);
            }
        }

        private static void Timeover(this BulletComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);

            Unit owner = self.GetOwner();
            if (owner == null || owner.IsDisposed)
            {
                self.DoDispose();
                return;
            }

            Unit bullet = self.GetParent<Unit>();

            BulletConfig config = self.Config;
            if (config.DestroyActions.Count > 0)
            {
                foreach (int action in config.DestroyActions)
                {
                    self.Create(action, bullet, bullet, ActionTriggerType.BulletDestroy);
                }
            }

            self.DoDispose();
        }

        private static void DoDispose(this BulletComponent self)
        {
            self.GetParent<Unit>().Stop(0);

            self.Scene().GetComponent<UnitComponent>().Remove(self.Parent.Id);
        }

        private static void PreDestroy(this BulletComponent self)
        {
            Unit owner = self.GetOwner();
            if (owner == null)
            {
                return;
            }

            BulletConfig config = self.Config;
            if (config.DestroyActions.Count < 1)
            {
                return;
            }

            foreach (int destroyAction in config.DestroyActions)
            {
                self.Create(destroyAction, owner, owner, ActionTriggerType.BulletDestroy);
            }
        }

        public static Unit GetOwner(this BulletComponent self)
        {
            return self.Scene().GetComponent<UnitComponent>().Get(self.OwnerId);
        }
    }
}