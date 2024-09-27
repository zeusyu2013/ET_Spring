namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SoulOnBattleHandler : MessageLocationHandler<Unit, C2M_SoulOnBattle, M2C_SoulOnBattle>
    {
        protected override async ETTask Run(Unit unit, C2M_SoulOnBattle request, M2C_SoulOnBattle response)
        {
            response.Error = unit.GetComponent<SoulComponent>().Battle(0, request.SoulConfigId, request.Position);

            await ETTask.CompletedTask;
        }
    }
}