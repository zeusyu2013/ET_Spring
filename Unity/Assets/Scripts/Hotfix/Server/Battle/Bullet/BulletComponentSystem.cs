namespace ET.Server
{
    [EntitySystemOf(typeof(BulletComponent))]
    [FriendOfAttribute(typeof(ET.Server.BulletComponent))]
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

        [EntitySystem]
        private static void Awake(this ET.Server.BulletComponent self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<ActionTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BulletComponent self)
        {
            self.PreDestroy();
            self.ConfigId = default;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TickTimer);
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
            using (ListComponent<Unit> list = ListComponent<Unit>.Create())
            {
                
            }
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