namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SoulUpstarHandler : MessageLocationHandler<Unit, C2M_SoulUpstar, M2C_SoulUpstar>
    {
        protected override async ETTask Run(Unit unit, C2M_SoulUpstar request, M2C_SoulUpstar response)
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

            response.Error = soul.Upstar();

            await ETTask.CompletedTask;
        }
    }
}