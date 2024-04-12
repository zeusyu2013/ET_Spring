namespace ET
{
    [EntitySystemOf(typeof(SelectTargetComponent))]
    public static partial class SelectTargetComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.SelectTargetComponent self)
        {
        }

        public static void Check(this SelectTargetComponent self, int configId, int level)
        {
            SkillConfig config = SkillConfigCategory.Instance.Get(configId, level);

            ASelectTargetHandler handler = SelectTargetDispatcherComponent.Instance.Get(config.SkillRange.ToString());
            if (handler == null)
            {
                return;
            }

            int ret = handler.Check(self, config);
        }
    }
}