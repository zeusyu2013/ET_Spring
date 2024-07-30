namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class BuffAdd_ClientHandler : AEvent<Scene, BuffAdd>
    {
        protected override async ETTask Run(Scene scene, BuffAdd args)
        {
            ClientBuff buff = args.Unit.GetComponent<ClientBuffComponent>().Get(args.BuffId);
            if (buff == null)
            {
                return;
            }

            BuffConfig config = buff.Config;
            // todo:播放特效
            //config.Fx
            
            await ETTask.CompletedTask;
        }
    }
}