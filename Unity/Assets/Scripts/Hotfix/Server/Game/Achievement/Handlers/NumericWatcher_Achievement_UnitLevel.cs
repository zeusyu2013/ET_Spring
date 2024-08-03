namespace ET.Server
{
    [NumericWatcher(SceneType.Current, (int)GamePropertyType.GP_Level)]
    public class NumericWatcher_Achievement_UnitLevel : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit.Type() != UnitType.UnitType_Player)
            {
                return;
            }

            AchievementComponent achievementComponent = unit.GetComponent<AchievementComponent>();
            if (achievementComponent == null)
            {
                return;
            }

            achievementComponent.AddAchievement(AchievementType.AchievementType_PropertyCompare);
        }
    }
}