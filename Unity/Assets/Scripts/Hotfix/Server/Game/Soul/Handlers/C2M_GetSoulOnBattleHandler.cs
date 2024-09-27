namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GetSoulOnBattleHandler : MessageLocationHandler<Unit, C2M_GetSoulOnBattle, M2C_GetSoulOnBattle>
    {
        protected override async ETTask Run(Unit unit, C2M_GetSoulOnBattle request, M2C_GetSoulOnBattle response)
        {
            response.Battles = unit.GetComponent<SoulComponent>().GetBattle();

            await ETTask.CompletedTask;
        }
    }
}