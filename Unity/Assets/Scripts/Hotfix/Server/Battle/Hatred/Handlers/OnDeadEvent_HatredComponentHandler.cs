namespace ET.Server
{
    [Event(SceneType.Map)]
    public class OnDeadEvent_HatredComponentHandler : AEvent<Scene, OnDeadEvent>
    {
        protected override async ETTask Run(Scene scene, OnDeadEvent args)
        {
            await ETTask.CompletedTask;
        }
    }
}