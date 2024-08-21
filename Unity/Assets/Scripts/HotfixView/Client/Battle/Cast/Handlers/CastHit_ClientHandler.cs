namespace ET.Client
{
    [Event((SceneType.MainClient))]
    [FriendOfAttribute(typeof(ET.Client.ClientCast))]
    public class CastHit_ClientHandler : AEvent<Scene, CastHit>
    {
        protected override async ETTask Run(Scene scene, CastHit args)
        {
            Unit target = scene.CurrentScene().GetUnit(args.TargetId);
            if (target == null)
            {
                return;
            }

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

            CastClientConfig config = CastClientConfigCategory.Instance.Get(cast.ConfigId);

            target.GetComponent<AnimatorComponent>()?.Play(config.CastHitAnimation);

            // todo 播放受击特效

            await ETTask.CompletedTask;
        }
    }
}