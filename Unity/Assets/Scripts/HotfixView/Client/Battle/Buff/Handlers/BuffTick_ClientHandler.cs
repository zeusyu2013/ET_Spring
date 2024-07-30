namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class BuffTick_ClientHandler : AEvent<Scene, BuffTick>
    {
        protected override async ETTask Run(Scene scene, BuffTick args)
        {
            await ETTask.CompletedTask;
        }
    }
}