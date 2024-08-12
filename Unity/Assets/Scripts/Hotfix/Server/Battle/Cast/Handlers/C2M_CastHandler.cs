namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_CastHandler : MessageLocationHandler<Unit, C2M_Cast, M2C_Cast>
    {
        protected override async ETTask Run(Unit unit, C2M_Cast request, M2C_Cast response)
        {
            int err = BattleHelper.CanCast(unit, request.CastConfigId);
            if (err != ErrorCode.ERR_Success)
            {
                response.Error = err;
                return;
            }

            response.Error = unit.CreateAndCast(request.CastConfigId, request.TargetId);

            await ETTask.CompletedTask;
        }
    }
}