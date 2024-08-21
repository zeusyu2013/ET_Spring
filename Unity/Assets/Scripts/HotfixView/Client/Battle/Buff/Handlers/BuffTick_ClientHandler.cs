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
            string fxName = config.TickFx;
            if (!string.IsNullOrEmpty(fxName))
            {
                // 播放特效
                await scene.CurrentScene().GetComponent<FxComponent>().Spwan(fxName, args.Unit.GetComponent<GameObjectComponent>().Transform);
            }
        }
    }
}