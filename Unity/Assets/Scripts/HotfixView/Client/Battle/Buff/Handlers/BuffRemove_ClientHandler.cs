namespace ET.Client
{
    [Event(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.Client.ClientBuff))]
    public class BuffRemove_ClientHandler : AEvent<Scene, BuffRemove>
    {
        protected override async ETTask Run(Scene scene, BuffRemove args)
        {
            ClientBuff buff = args.Unit.GetComponent<ClientBuffComponent>().Get(args.BuffId);
            if (buff == null)
            {
                return;
            }

            BuffClientConfig config = BuffClientConfigCategory.Instance.Get(buff.ConfigId);
            
            // 播放特效
            await scene.CurrentScene().GetComponent<FxComponent>()
                    .PlayFx(args.Unit, config.RemoveFx, config.RemoveFxBindPoint, config.RemoveFxTime);
        }
    }
}