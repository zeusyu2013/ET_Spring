namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class DailyNotify_ShopComponentHandler : MessageHandler<Scene, DailyNotify>
    {
        protected override async ETTask Run(Scene scene, DailyNotify message)
        {
            foreach ((long _, Entity entity) in scene.GetComponent<UnitComponent>().Children)
            {
                Unit unit = entity as Unit;
                if (unit == null || unit.IsDisposed)
                {
                    continue;
                }

                unit.GetComponent<ShopComponent>()?.NewDay();
            }

            await ETTask.CompletedTask;
        }
    }
}