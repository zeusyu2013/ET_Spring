namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class NetClient2Main_PingHandler : MessageHandler<Scene, NetClient2Main_Ping>
    {
        protected override async ETTask Run(Scene entity, NetClient2Main_Ping message)
        {
            EventSystem.Instance.Publish(entity, new UIPing{ Ping = message.Ping});
            await ETTask.CompletedTask;
        }
    }
}

