namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RideMountHandler : MessageLocationHandler<Unit, C2M_RideMount, M2C_RideMount>
    {
        protected override async ETTask Run(Unit unit, C2M_RideMount request, M2C_RideMount response)
        {
            unit.GetComponent<MountComponent>().Ride(request.MountConfigId);
            
            await ETTask.CompletedTask;
        }
    }
}