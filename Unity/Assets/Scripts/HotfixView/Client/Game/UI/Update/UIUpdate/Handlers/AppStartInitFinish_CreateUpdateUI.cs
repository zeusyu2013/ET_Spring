namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class AppStartInitFinish_CreateUpdateUI : AEvent<Scene, AppStartInitFinish>
    {
        protected override async ETTask Run(Scene root, AppStartInitFinish args)
        {
            //await root.GetComponent<RemoteConfigComponent>().GetRemoteConfig();

            //await UIHelper.Create(root, UIName.UIUpdate);

            await ETTask.CompletedTask;
        }
    }
}