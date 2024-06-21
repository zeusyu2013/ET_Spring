namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BuyItemHandler : MessageLocationHandler<Unit, C2M_BuyItem, M2C_BuyItem>
    {
        protected override async ETTask Run(Unit unit, C2M_BuyItem request, M2C_BuyItem response)
        {
            unit.GetComponent<ShopComponent>().BuyItem(request.ItemConfig, request.ItemAmount);
            
            await ETTask.CompletedTask;
        }
    }
}