namespace ET.Server
{
    [Event(SceneType.Map)]
    public class LevelChanged_LevelComponentHandler : AEvent<Scene, LevelChanged>
    {
        protected override async ETTask Run(Scene scene, LevelChanged args)
        {
            Unit unit = args.Unit;
            int newLevel = args.NewLevel;

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                return;
            }

            ExpConfig config = ExpConfigCategory.Instance.Get(newLevel);

            // 等级属性是累加
            numericComponent.AddPropertyPack(config.Property);

            await ETTask.CompletedTask;
        }
    }
}