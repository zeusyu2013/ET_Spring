namespace ET.Server
{
    [EntitySystemOf(typeof(TransmogrificationComponent))]
    [FriendOfAttribute(typeof(ET.Server.TransmogrificationComponent))]
    public static partial class TransmogrificationComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.TransmogrificationComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.TransmogrificationComponent self)
        {
        }

        public static void AddTransmogrification(this TransmogrificationComponent self, int equipmentConfig)
        {
            TransmogrificationConfig config = TransmogrificationConfigCategory.Instance.Get(equipmentConfig);
            if (config == null)
            {
                return;
            }

            if (self.Transmogrifications.Contains(config.TransConfig))
            {
                return;
            }

            self.Transmogrifications.Add(config.TransConfig);
        }
    }
}