namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SoulLevelBreakHandler : MessageLocationHandler<Unit, C2M_SoulLevelBreak, M2C_SoulLevelBreak>
    {
        protected override async ETTask Run(Unit unit, C2M_SoulLevelBreak request, M2C_SoulLevelBreak response)
        {
            Soul soul = unit.GetComponent<SoulComponent>().Get(request.SoulConfigId);
            if (soul == null)
            {
                response.Error = ErrorCode.ERR_SoulNotFound;
                return;
            }

            response.Error = soul.LevelBreak();

            await ETTask.CompletedTask;
        }
    }
}