namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UpgradeLotteryHandler : MessageLocationHandler<Unit, C2M_UpgradeLottery, M2C_UpgradeLottery>
    {
        protected override async ETTask Run(Unit unit, C2M_UpgradeLottery request, M2C_UpgradeLottery response)
        {
            response.Error = unit.GetComponent<LotteryComponent>().Upgrade();

            await ETTask.CompletedTask;
        }
    }
}