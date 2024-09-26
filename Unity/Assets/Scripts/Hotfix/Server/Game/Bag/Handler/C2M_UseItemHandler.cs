namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_UseItemHandler : MessageLocationHandler<Unit, C2M_UseItem, M2C_UseItem>
    {
        protected override async ETTask Run(Unit unit, C2M_UseItem request, M2C_UseItem response)
        {
            int errorCode = unit.GetComponent<BagComponent>().UseItem(request.ConfigId, request.Amount);
            if (errorCode == ErrorCode.ERR_Success)
            {
                response.ConfigId = request.ConfigId;
                response.Amount = request.Amount;
            }
            else
            {
                response.Error = errorCode;
            }

            await ETTask.CompletedTask;
        }
    }
}