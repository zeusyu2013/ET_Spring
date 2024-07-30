namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class BuffRemove_ClientHandler : AEvent<Scene, BuffRemove>
    {
        protected override async ETTask Run(Scene scene, BuffRemove args)
        {
            await ETTask.CompletedTask;
        }
    }
}