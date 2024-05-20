namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetOfflineIncomeHandler : MessageLocationHandler<Unit, C2M_GetOfflineIncome, M2C_GetOfflineIncome>
    {
        protected override async ETTask Run(Unit unit, C2M_GetOfflineIncome request, M2C_GetOfflineIncome response)
        {
            OfflineIncomeComponent offlineIncomeComponent = unit.GetComponent<OfflineIncomeComponent>();
            if (offlineIncomeComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "没找到离线收益组件";
                return;
            }
            
            OfflineIncomeInfo info = offlineIncomeComponent.GetOfflineIncome();

            response.OfflineIncomeInfo = info;
            
            await ETTask.CompletedTask;
        }
    }
}