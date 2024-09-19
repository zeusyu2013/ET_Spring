namespace ET.Client
{
    [Event(SceneType.Main)]
    public class ResourcesUpdateOverHandler : AEvent<Scene, ResourcesUpdateOver>
    {
        protected override async ETTask Run(Scene scene, ResourcesUpdateOver args)
        {
            bool success = args.Success;
            
            // todo:更新完成，跳转登录界面
            
            await ETTask.CompletedTask;
        }
    }
}