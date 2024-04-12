namespace ET
{
    [EntitySystemOf(typeof(Skill))]
    [FriendOfAttribute(typeof(ET.Skill))]
    public static partial class SkillSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Skill self, int configId, int level)
        {
            self.ConfigId = configId;
            self.Level = level;
        }

        [EntitySystem]
        private static void Destroy(this ET.Skill self)
        {
        }
    }
}