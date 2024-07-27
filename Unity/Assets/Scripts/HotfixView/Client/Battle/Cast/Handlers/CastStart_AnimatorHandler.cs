namespace ET.Client
{
    [Event(SceneType.Current)]
    public class CastStart_AnimatorHandler : AEvent<Scene, CastStart>
    {
        protected override async ETTask Run(Scene scene, CastStart args)
        {
            Unit unit = scene.GetUnit(args.CasterId);
            if (unit == null)
            {
                return;
            }
            
            await unit.GetComponent<AnimatorComponent>()?.Play("");
        }
    }
}