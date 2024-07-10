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

        [EntitySystem]
        private static void Deserialize(this AchievementComponent self)
        {
            Unit unit = self.GetParent<Unit>();

            foreach (int achievement in self.Achievements)
            {
                AchievementConfig config = AchievementConfigCategory.Instance.Get(achievement);
                if (config == null)
                {
                    continue;
                }

                unit.GetComponent<NumericComponent>().AddPropertyPack(config.Property);
            }
        }

        public static void AddAchievement(this AchievementComponent self, AchievementType type)
        {
            var configs = AchievementConfigCategory.Instance.DataList;
            if (configs == null || configs.Count < 1)
            {
                return;
            }

            foreach (AchievementConfig config in configs)
            {
                if (config.AchievementType != type)
                {
                    continue;
                }
                
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

                    case CurrencyCompare.__ID__:
                    {
                        CurrencyCompare currencyCompare = (CurrencyCompare)config.Condition;
                        long value = self.GetParent<Unit>().GetComponent<CurrencyComponent>().GetCurrencyValue(currencyCompare.CurrencyType);
                        if (value >= currencyCompare.Value)
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