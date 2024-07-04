namespace ET.Server
{
    [MessageHandler(SceneType.RequestHall)]
    public class M2Request_GetRequestsHandler : MessageHandler<Scene, M2Request_GetRequests, Request2M_GetRequests>
    {
        protected override async ETTask Run(Scene scene, M2Request_GetRequests request, Request2M_GetRequests response)
        {
            response.GameRequestInfos = scene.GetComponent<RequestHallComponent>().GetRequests(request.UnitId);

            await ETTask.CompletedTask;
        }
    }
}