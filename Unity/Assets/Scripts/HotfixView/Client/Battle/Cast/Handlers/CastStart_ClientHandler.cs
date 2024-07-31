namespace ET.Client
{
    [Event(SceneType.Current)]
    public class CastStart_ClientHandler : AEvent<Scene, CastStart>
    {
        protected override async ETTask Run(Scene scene, CastStart args)
        {
            Unit unit = scene.CurrentScene().GetUnit(args.CasterId);
            if (unit == null)
            {
                return;
            }

            CastConfig config = CastConfigCategory.Instance.Get(args.CastConfigId);
            
            // 播放动画
            await unit.GetComponent<AnimatorComponent>()?.Play(config.CastStartAnimation);
            
            // 播放特效
            
        }
    }
}