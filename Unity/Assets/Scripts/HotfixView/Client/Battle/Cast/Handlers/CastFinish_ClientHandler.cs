namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class CastFinish_ClientHandler : AEvent<Scene, CastFinish>
    {
        protected override async ETTask Run(Scene scene, CastFinish args)
        {
            await ETTask.CompletedTask;
        }
    }
}