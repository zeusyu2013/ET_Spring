namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class DailyNotify_DailyComponentHandler : MessageHandler<Scene, DailyNotify>
    {
        protected override async ETTask Run(Scene scene, DailyNotify message)
        {
            int dailyConfig = message.DailyConfig;
            DailyConfig config = DailyConfigCategory.Instance.Get(dailyConfig);
            if (config == null)
            {
                return;
            }
            
            await ETTask.CompletedTask;
        }
    }
}