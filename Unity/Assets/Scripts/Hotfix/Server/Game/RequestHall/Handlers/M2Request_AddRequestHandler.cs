namespace ET.Server
{
    [MessageHandler(SceneType.RequestHall)]
    public class M2Request_AddRequestHandler : MessageHandler<Scene, M2Request_AddRequest, Request2M_AddRequest>
    {
        protected override async ETTask Run(Scene scene, M2Request_AddRequest request, Request2M_AddRequest response)
        {
            scene.GetComponent<RequestHallComponent>().AddRequest(request.UnitId, request.SenderUnitId, request.RequestType);

            await ETTask.CompletedTask;
        }
    }
}