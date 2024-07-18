namespace ET.Server
{
    [Event(SceneType.Map)]
    public class LevelChanged_TalentComponentHandler : AEvent<Scene, LevelChanged>
    {
        protected override async ETTask Run(Scene scene, LevelChanged args)
        {
            Unit unit = args.Unit;
            int oldLevel = args.OldLevel;
            int newLevel = args.NewLevel;

            unit.GetComponent<TalentComponent>().AddTalentPoint(newLevel - oldLevel);

            await ETTask.CompletedTask;
        }
    }
}