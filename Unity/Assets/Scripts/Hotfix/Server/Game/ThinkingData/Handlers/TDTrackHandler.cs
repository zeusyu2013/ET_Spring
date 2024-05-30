namespace ET.Server
{
    [MessageHandler(SceneType.Log)]
    public class TDTrackHandler : MessageHandler<Scene, TDTrack>
    {
        protected override async ETTask Run(Scene scene, TDTrack message)
        {
            scene.GetComponent<ThinkingDataComponent>().Track(message.AccountId, "", message.EventName, message.Properties);
            
            await ETTask.CompletedTask;
        }
    }
}