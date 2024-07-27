namespace ET.Server
{
    [EntitySystemOf(typeof(Skill))]
    [FriendOfAttribute(typeof(Skill))]
    public static partial class SkillSystem
    {
        [EntitySystem]
        private static void Awake(this Skill self, int configId, int level)
        {
            self.ConfigId = configId;
            self.Level = level;

            self.AddComponent<ActionTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this Skill self)
        {
        }
    }
}