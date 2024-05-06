namespace ET
{
    [EntitySystemOf(typeof(DungeonsComponent))]
    [FriendOfAttribute(typeof(ET.DungeonsComponent))]
    public static partial class DungeonsComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.DungeonsComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.DungeonsComponent self)
        {
        }

        public static void EnterDungeons(this DungeonsComponent self, int dungeonsConfig)
        {
            if (dungeonsConfig < 1)
            {
                return;
            }

            DungeonsConfig config = DungeonsConfigCategory.Instance.Get(dungeonsConfig);
            if (config == null)
            {
                return;
            }

            // 前置未过关
            if (config.PreStage != 0 && !self.Dungeons.ContainsKey(config.PreStage))
            {
                return;
            }
            
            
        }

        public static void ExitDungeons(this DungeonsComponent self, int dungeonsConfig)
        {
            if (dungeonsConfig < 1)
            {
                return;
            }

            DungeonsConfig config = DungeonsConfigCategory.Instance.Get(dungeonsConfig);
            if (config == null)
            {
                return;
            }
        }
    }
}