namespace ET.Server
{
    [MessageHandler(SceneType.RequestHall)]
    public class Manager2Request_ShutDownHandler : MessageHandler<Scene, Manager2Request_ShutDown, Request2Manager_ShutDown>
    {
        protected override async ETTask Run(Scene scene, Manager2Request_ShutDown request, Request2Manager_ShutDown response)
        {
            await scene.GetComponent<RequestHallComponent>().Save();
        }
    }
}