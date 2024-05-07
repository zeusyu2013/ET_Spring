namespace ET
{
    [NumericWatcher(SceneType.Current, (int)GamePropertyType.GamePropertyType_Gold)]
    public class NumericWatcher_Achievement_UnitGold : INumericWatcher
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