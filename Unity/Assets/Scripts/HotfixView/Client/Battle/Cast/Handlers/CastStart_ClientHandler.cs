namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class CastStart_ClientHandler : AEvent<Scene, CastStart>
    {
        protected override async ETTask Run(Scene scene, CastStart args)
        {
            Unit unit = scene.CurrentScene().GetUnit(args.CasterId);
            if (unit == null)
            {
                return;
            }

            CastClientConfig config = CastClientConfigCategory.Instance.Get(args.CastConfigId);

            // 播放动画
            await unit.GetComponent<AnimatorComponent>()?.Play(config.CastStartAnimation);

            // 播放特效
            await scene.CurrentScene().GetComponent<FxComponent>()
                    .PlayFx(unit, config.CastStartFx, config.CastStartFxBindPoint, config.CastStartFxTime);
        }
    }
}