namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PickupDropHandler : MessageLocationHandler<Unit, C2M_PickupDrop, M2C_PickupDrop>
    {
        protected override async ETTask Run(Unit unit, C2M_PickupDrop request, M2C_PickupDrop response)
        {
            long deadUnitId = request.DeadUnitId;
            if (deadUnitId < 1)
            {
                response.Error = ErrorCode.ERR_DropUnitNotFound;
                return;
            }

            UnitComponent unitComponent = unit.Scene().GetComponent<UnitComponent>();

            Unit deader = unitComponent.Get(deadUnitId);
            if (deader == null)
            {
                response.Error = ErrorCode.ERR_DropUnitNotFound;
                return;
            }
            
            await ETTask.CompletedTask;
        }
    }
}