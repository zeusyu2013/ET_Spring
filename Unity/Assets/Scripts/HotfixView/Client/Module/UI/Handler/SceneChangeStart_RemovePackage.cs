namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class SceneChangeStart_RemovePackage : AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, SceneChangeStart a)
        {
            var uiComponent = scene.GetComponent<UIComponent>();
            if (uiComponent == null)
            {
                return;
            }

            var packageComponent = uiComponent.GetComponent<UIPackageComponent>();
            packageComponent?.RemoveUselessPackage();
            
            await ETTask.CompletedTask;
        }
    }
}

