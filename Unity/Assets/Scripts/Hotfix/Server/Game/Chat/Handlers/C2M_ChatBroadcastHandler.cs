namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_ChatBroadcastHandler : MessageLocationHandler<Scene, C2M_ChatBroadcast>
    {
        protected override async ETTask Run(Scene scene, C2M_ChatBroadcast message)
        {
            scene.GetComponent<ChatComponent>().Broadcast(message.ChannelId, message.Content);

            await ETTask.CompletedTask;
        }
    }
}