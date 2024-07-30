namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_CastHandler : MessageLocationHandler<Unit, C2M_Cast, M2C_Cast>
    {
        protected override async ETTask Run(Unit unit, C2M_Cast request, M2C_Cast response)
        {
            CastConfig config = CastConfigCategory.Instance.Get(request.CastConfigId);
            if (config == null)
            {
                response.Error = ErrorCode.ERR_SkillConfigNotFound;
                return;
            }

            if (!unit.IsAlive())
            {
                response.Error = ErrorCode.ERR_AlreadyDead;
                return;
            }

            response.Error = unit.CreateAndCast(request.CastConfigId);

            await ETTask.CompletedTask;
        }
    }
}