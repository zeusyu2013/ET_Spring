namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SoulUplevelHandler : MessageLocationHandler<Unit, C2M_SoulUplevel, M2C_SoulUplevel>
    {
        protected override async ETTask Run(Unit unit, C2M_SoulUplevel request, M2C_SoulUplevel response)
        {
            SoulComponent soulComponent = unit.GetComponent<SoulComponent>();
            if (soulComponent == null)
            {
                return;
            }

            Soul soul = soulComponent.GetChild<Soul>(request.SoulId);
            if (soul == null)
            {
                response.Error = ErrorCode.ERR_SoulNotFound;
                return;
            }

            response.Error = soul.Uplevel(0);
            
            await ETTask.CompletedTask;
        }
    }
}