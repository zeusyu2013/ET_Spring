namespace ET.Server
{
    [MessageHandler(SceneType.Log)]
    public class TDUserSetOnceHandler : MessageHandler<Scene, TDUserSetOnce>
    {
        protected override async ETTask Run(Scene scene, TDUserSetOnce message)
        {
            scene.GetComponent<ThinkingDataComponent>().UserSetOnce(message.AccountId, "", message.Properties);

            await ETTask.CompletedTask;
        }
    }
}