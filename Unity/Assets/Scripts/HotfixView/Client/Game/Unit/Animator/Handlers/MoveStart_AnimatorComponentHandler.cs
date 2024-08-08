namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MoveStart_AnimatorComponentHandler : AEvent<Scene, MoveStart>
    {
        protected override async ETTask Run(Scene scene, MoveStart args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }
            
            unit.GetComponent<AnimatorComponent>()?.Play("run");
            
            await ETTask.CompletedTask;
        }
    }
}