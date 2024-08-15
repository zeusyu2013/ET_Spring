namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetDropItemsHandler : MessageLocationHandler<Unit, C2M_GetDropItems, M2C_GetDropItems>
    {
        protected override async ETTask Run(Unit unit, C2M_GetDropItems request, M2C_GetDropItems response)
        {
            Unit monster = unit.Scene().GetComponent<UnitComponent>().Get(request.UnitId);
            if (monster == null || monster.IsDisposed)
            {
                response.Error = ErrorCode.ERR_DropUnitNotFound;
                return;
            }

            response.GameItemInfos = monster.GetComponent<DropBagComponent>().ToMessage();
            
            await ETTask.CompletedTask;
        }
    }
}