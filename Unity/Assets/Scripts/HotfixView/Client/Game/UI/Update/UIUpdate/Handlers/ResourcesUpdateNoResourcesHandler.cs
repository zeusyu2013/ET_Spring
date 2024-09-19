namespace ET.Client
{
    [Event(SceneType.Main)]
    public class ResourcesUpdateNoResourcesHandler : AEvent<Scene, ResourcesUpdateNoResources>
    {
        protected override async ETTask Run(Scene scene, ResourcesUpdateNoResources args)
        {
            // todo:跳转登录界面
            
            await ETTask.CompletedTask;
        }
    }
}