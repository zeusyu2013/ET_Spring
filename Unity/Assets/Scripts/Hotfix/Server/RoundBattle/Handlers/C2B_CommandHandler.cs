using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.RoundBattle)]
    public class C2B_CommandHandler : MessageLocationHandler<Unit, C2B_Command, B2C_Command>
    {
        protected override async ETTask Run(Unit unit, C2B_Command request, B2C_Command response)
        {
            SoulComponent soulComponent = unit.GetComponent<SoulComponent>();

            Dictionary<int, int> battles = soulComponent.GetBattle();
            if (!battles.ContainsKey(request.SoulConfigId))
            {
                response.Error = ErrorCode.ERR_SoulNotOnBattle;
                return;
            }

            Unit soul = unit.Scene().GetComponent<UnitComponent>().Get(request.SoulId);
            if (soul == null || soul.IsDisposed)
            {
                response.Error = ErrorCode.ERR_SoulNotFoundOnBattle;
                return;
            }

            response.Error = soul.CreateAndCast(request.SoulCastConfigId, request.TargetId);

            await ETTask.CompletedTask;
        }
    }
}