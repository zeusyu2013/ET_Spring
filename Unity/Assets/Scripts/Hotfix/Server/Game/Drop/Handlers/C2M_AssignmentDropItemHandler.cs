namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AssignmentDropItemHandler : MessageLocationHandler<Unit, C2M_AssignmentDropItem, M2C_AssignmentDropItem>
    {
        protected override async ETTask Run(Unit unit, C2M_AssignmentDropItem request, M2C_AssignmentDropItem response)
        {
            Unit monster = unit.Scene().GetComponent<UnitComponent>().Get(request.MonsterId);
            if (monster == null || monster.IsDisposed)
            {
                response.Error = ErrorCode.ERR_DropUnitNotFound;
                return;
            }

            response.Error = await monster.GetComponent<DropBagComponent>()
                    .Assignment(request.UnitId, request.TeamId, request.AssignmentUnitId, request.ItemConfigId);
        }
    }
}