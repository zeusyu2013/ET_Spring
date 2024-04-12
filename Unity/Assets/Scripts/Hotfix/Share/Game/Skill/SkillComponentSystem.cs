namespace ET
{
    [EntitySystemOf(typeof(SkillComponent))]
    [FriendOfAttribute(typeof(ET.SkillComponent))]
    public static partial class SkillComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.SkillComponent self)
        {
            int configId = self.GetParent<Unit>().ConfigId;
            UnitConfig config = UnitConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                Log.Error($"Unit Config没有找到: {configId}");
                return;
            }

            self.Skills = config.Skills;
        }

        [EntitySystem]
        private static void Destroy(this ET.SkillComponent self)
        {
            self.Skills.Clear();
        }

        private static void CreateSkillEntities(this SkillComponent self)
        {
            if (self.Skills.Count < 1)
            {
                return;
            }

            foreach (int skillConfig in self.Skills)
            {
                self.AddChild<Skill, int, int>(skillConfig, 1);
            }
        }
    }
}