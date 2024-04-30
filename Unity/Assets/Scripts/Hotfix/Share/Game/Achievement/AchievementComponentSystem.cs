namespace ET
{
    [EntitySystemOf(typeof(AchievementComponent))]
    [FriendOfAttribute(typeof(ET.AchievementComponent))]
    [FriendOfAttribute(typeof(ET.Achievement))]
    public static partial class AchievementComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.AchievementComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.AchievementComponent self)
        {
            foreach (Entity childrenValue in self.Children.Values)
            {
                Achievement achievement = childrenValue as Achievement;
                if (achievement == null)
                {
                    continue;
                }

                int config = achievement.AchievementConfig;
                if (config < 1)
                {
                    continue;
                }

                if (self.Achievements.ContainsKey(config))
                {
                    Log.Error($"包含相同id成就 {config}");
                    continue;
                }

                self.Achievements.Add(config, achievement);
            }
        }

        public static void AddAchievement(this AchievementComponent self, int achievementConfig)
        {
            if (self.Achievements.ContainsKey(achievementConfig))
            {
                return;
            }

            AchievementConfig config = AchievementConfigCategory.Instance.Get(achievementConfig);
            if (config == null)
            {
                return;
            }
        }
    }
}