namespace ET.Server
{
    [Event(SceneType.Map)]
    public class MountChanged_MountComponentHandler : AEvent<Scene, MountChanged>
    {
        protected override async ETTask Run(Scene scene, MountChanged args)
        {
            Unit unit = args.Unit;
            int newMount = args.NewMount;
            if (newMount < 1)
            {
                // todo 还原角色移动速度**百分比值**
                return;
            }

            MountConfig config = MountConfigCategory.Instance.Get(newMount);
            if (config == null)
            {
                Log.Error($"坐骑配置有误，请检查配置 {newMount}");
                return;
            }
            
            // todo 设置玩家移动速度**百分比值**
            // config.SpeedRate

            await ETTask.CompletedTask;
        }
    }
}