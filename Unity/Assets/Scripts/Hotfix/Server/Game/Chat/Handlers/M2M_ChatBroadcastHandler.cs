namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_ChatBroadcastHandler : MessageHandler<Scene, M2M_ChatBroadcast>
    {
        protected override async ETTask Run(Scene scene, M2M_ChatBroadcast message)
        {
            foreach (var entity in scene.GetComponent<UnitComponent>().Children.Values)
            {
                var unit = (Unit)entity;

                M2C_ChatBroadcast m2CChatBroadcast = M2C_ChatBroadcast.Create();
                m2CChatBroadcast.ChannelId = message.ChannelId;
                m2CChatBroadcast.Content = message.Content;
                MapMessageHelper.SendToClient(unit, m2CChatBroadcast);
            }

            await ETTask.CompletedTask;
        }
    }
}