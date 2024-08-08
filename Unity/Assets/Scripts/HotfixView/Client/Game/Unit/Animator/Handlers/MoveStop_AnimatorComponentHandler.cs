namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MoveStop_AnimatorComponentHandler : AEvent<Scene, MoveStop>
    {
        protected override async ETTask Run(Scene scene, MoveStop args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }
            
            unit.GetComponent<AnimatorComponent>()?.Play("idle");
            
            await ETTask.CompletedTask;
        }
    }
}