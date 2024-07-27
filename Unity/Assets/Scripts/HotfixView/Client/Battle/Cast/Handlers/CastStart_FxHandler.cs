namespace ET.Client
{
    [Event(SceneType.Current)]
    public class CastStart_FxHandler : AEvent<Scene, CastStart>
    {
        protected override async ETTask Run(Scene scene, CastStart args)
        {
            Unit caster = scene.GetComponent<UnitComponent>().Get(args.CasterId);
            if (caster == null)
            {
                return;
            }

            await ETTask.CompletedTask;
        }
    }
}