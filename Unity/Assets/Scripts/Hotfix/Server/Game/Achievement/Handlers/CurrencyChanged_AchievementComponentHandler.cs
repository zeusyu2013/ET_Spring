namespace ET.Server
{
    [Event(SceneType.Map)]
    public class CurrencyChanged_AchievementComponentHandler : AEvent<Scene, CurrencyChanged>
    {
        protected override async ETTask Run(Scene scene, CurrencyChanged args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            unit.GetComponent<AchievementComponent>().AddAchievement(AchievementType.AchievementType_Currency);

            await ETTask.CompletedTask;
        }
    }
}