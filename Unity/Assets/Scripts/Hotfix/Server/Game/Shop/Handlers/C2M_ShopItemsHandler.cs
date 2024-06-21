namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ShopItemsHandler : MessageLocationHandler<Unit, C2M_ShopItems, M2C_ShopItems>
    {
        protected override async ETTask Run(Unit unit, C2M_ShopItems request, M2C_ShopItems response)
        {
            response.ShopItemInfos = unit.GetComponent<ShopComponent>().ToMessage();

            await ETTask.CompletedTask;
        }
    }
}