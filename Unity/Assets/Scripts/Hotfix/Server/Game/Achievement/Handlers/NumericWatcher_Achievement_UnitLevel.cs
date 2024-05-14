namespace ET.Server
{
    [NumericWatcher(SceneType.Current, (int)GamePropertyType.GamePropertyType_Level)]
    public class NumericWatcher_Achievement_UnitLevel : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit.Type() != UnitType.Player)
            {
                return;
            }

            AchievementComponent achievementComponent = unit.GetComponent<AchievementComponent>();
            if (achievementComponent == null)
            {
                return;
            }

            achievementComponent.AddAchievement();
        }
    }
}