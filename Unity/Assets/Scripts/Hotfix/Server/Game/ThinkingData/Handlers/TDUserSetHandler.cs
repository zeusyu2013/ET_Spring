namespace ET.Server
{
    [MessageHandler(SceneType.Log)]
    public class TDUserSetHandler : MessageHandler<Scene, TDUserSet>
    {
        protected override async ETTask Run(Scene scene, TDUserSet message)
        {
            scene.GetComponent<ThinkingDataComponent>().UserSet(message.AccountId, "", message.Properties);

            await ETTask.CompletedTask;
        }
    }
}