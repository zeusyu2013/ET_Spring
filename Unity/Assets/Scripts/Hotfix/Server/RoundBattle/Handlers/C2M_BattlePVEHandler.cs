using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.RoundBattleComponent))]
    public class C2M_BattlePVEHandler : MessageLocationHandler<Unit, C2M_BattlePVE, M2C_BattlePVE>
    {
        protected override async ETTask Run(Unit unit, C2M_BattlePVE request, M2C_BattlePVE response)
        {
            Dictionary<int, int> battle = unit.GetComponent<SoulComponent>().GetBattle();
            if (battle.Count < 1)
            {
                response.Error = ErrorCode.ERR_NoSoulOnBattle;
                return;
            }

            Scene scene = EntitySceneFactory.CreateScene(unit.Scene(), unit.Id, IdGenerater.Instance.GenerateInstanceId(), SceneType.RoundBattle, "");
            scene.AddComponent<UnitComponent>();
            scene.AddComponent<TimerComponent>();

            RoundBattleComponent component = scene.AddComponent<RoundBattleComponent>();
            component.PVEConfig = request.PVEConfigId;
            component.Owner = unit;

            component.Start();

            await ETTask.CompletedTask;
        }
    }
}