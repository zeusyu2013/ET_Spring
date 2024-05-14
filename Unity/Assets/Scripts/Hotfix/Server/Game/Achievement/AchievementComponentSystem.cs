namespace ET.Server
{
    [EntitySystemOf(typeof(AchievementComponent))]
    [FriendOfAttribute(typeof(AchievementComponent))]
    public static partial class AchievementComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AchievementComponent self)
        {
        }

        public static void AddAchievement(this AchievementComponent self)
        {
            var configs = AchievementConfigCategory.Instance.DataList;
            if (configs == null || configs.Count < 1)
            {
                return;
            }

            foreach (AchievementConfig config in configs)
            {
                if (self.Achievements.Contains(config.Id))
                {
                    continue;
                }

                switch (config.Condition.GetTypeId())
                {
                    case PropertyCompare.__ID__:
                    {
                        PropertyCompare propertyCompare = (PropertyCompare)config.Condition;
                        int value = self.GetParent<Unit>().GetInt(propertyCompare.Property);
                        if (value >= propertyCompare.Value)
                        {
                            self.Achievements.Add(config.Id);
                        }

                        break;
                    }
                }
            }
        }
    }
}