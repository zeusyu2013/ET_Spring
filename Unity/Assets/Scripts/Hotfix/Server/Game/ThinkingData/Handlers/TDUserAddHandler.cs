namespace ET.Server
{
    [MessageHandler(SceneType.Log)]
    public class TDUserAddHandler : MessageHandler<Scene, TDUserAdd>
    {
        protected override async ETTask Run(Scene scene, TDUserAdd message)
        {
            scene.GetComponent<ThinkingDataComponent>().UserAdd(message.AccountId, "", message.Properties);
            
            await ETTask.CompletedTask;
        }
    }
}