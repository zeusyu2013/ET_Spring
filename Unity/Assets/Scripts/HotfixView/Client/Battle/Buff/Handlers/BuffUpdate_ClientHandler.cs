namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class BuffUpdate_ClientHandler : AEvent<Scene, BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, BuffUpdate args)
        {
            await ETTask.CompletedTask;
        }
    }
}