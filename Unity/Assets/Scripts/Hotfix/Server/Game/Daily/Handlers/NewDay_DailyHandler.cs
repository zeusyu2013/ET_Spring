namespace ET.Server
{
    [Event(SceneType.Map)]
    public class NewDay_DailyHandler : AEvent<Scene, NewDay>
    {
        protected override async ETTask Run(Scene scene, NewDay args)
        {
            foreach ((long _, Entity entity) in scene.GetComponent<UnitComponent>().Children)
            {
                Unit unit = entity as Unit;
                if (unit == null)
                {
                    continue;
                }

                unit.GetComponent<ShopComponent>().NewDay();
            }

            await ETTask.CompletedTask;
        }
    }
}