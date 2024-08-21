namespace ET.Client
{
    [Event(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.Client.ClientBuff))]
    public class BuffTick_ClientHandler : AEvent<Scene, BuffTick>
    {
        protected override async ETTask Run(Scene scene, BuffTick args)
        {
            ClientBuff buff = args.Unit.GetComponent<ClientBuffComponent>().Get(args.BuffId);
            if (buff == null)
            {
                return;
            }

            BuffClientConfig config = BuffClientConfigCategory.Instance.Get(buff.ConfigId);
            
            // 播放特效
            await scene.CurrentScene().GetComponent<FxComponent>()
                    .PlayFx(args.Unit, config.TickFx, config.TickFxBindPoint, config.TickFxTime);
        }
    }
}