namespace ET.Server
{
    [Event(SceneType.Map)]
    public class BuffTimeout_RemoveBuffHandler : AEvent<Scene, BuffTimeout>
    {
        protected override async ETTask Run(Scene scene, BuffTimeout args)
        {
            args.Unit?.GetComponent<BuffComponent>()?.Remove(args.BuffId);
            
            await ETTask.CompletedTask;
        }
    }
}