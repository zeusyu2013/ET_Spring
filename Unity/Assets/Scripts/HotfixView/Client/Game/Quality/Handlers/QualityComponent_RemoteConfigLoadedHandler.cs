namespace ET.Client
{
    [Event(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.Client.RemoteConfigComponent))]
    public class QualityComponent_RemoteConfigLoadedHandler : AEvent<Scene, RemoteConfigLoaded>
    {
        protected override async ETTask Run(Scene scene, RemoteConfigLoaded args)
        {
            string url = scene.GetComponent<RemoteConfigComponent>().RemoteConfig.QualityUrl;
            await scene.GetComponent<QualityComponent>().LoadRemoteConfig(url);
        }
    }
}