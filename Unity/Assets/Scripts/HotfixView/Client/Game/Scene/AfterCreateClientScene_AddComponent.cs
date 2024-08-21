namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class AfterCreateClientScene_AddComponent: AEvent<Scene, AfterCreateClientScene>
    {
        protected override async ETTask Run(Scene scene, AfterCreateClientScene args)
        {
            await ETTask.CompletedTask;
        }
    }
}