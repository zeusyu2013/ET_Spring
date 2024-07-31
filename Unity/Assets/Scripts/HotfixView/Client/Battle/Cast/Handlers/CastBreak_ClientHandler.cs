namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class CastBreak_ClientHandler : AEvent<Scene, CastBreak>
    {
        protected override async ETTask Run(Scene scene, CastBreak args)
        {
            Unit caster = scene.CurrentScene().GetUnit(args.CasterId);
            if (caster == null)
            {
                return;
            }

            ClientCast cast = caster.GetComponent<ClientCastComponent>().Get(args.CastId);
            if (cast == null)
            {
                return;
            }

            caster.GetComponent<AnimatorComponent>()?.Play("idle");

            await ETTask.CompletedTask;
        }
    }
}