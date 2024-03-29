using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetAllItemsHandler : MessageLocationHandler<Unit, C2M_GetAllItems, M2C_GetAllItems>
    {
        protected override async ETTask Run(Unit unit, C2M_GetAllItems request, M2C_GetAllItems response)
        {
            List<GameItemInfo> gameItemInfos = new();

            List<EntityRef<GameItem>> items = unit.GetComponent<BagComponent>().GetGameItems();
            foreach (var entityRef in items)
            {
                GameItem item = entityRef;
                gameItemInfos.Add(item.ToMessage());
            }

            response.GameItemInfos = gameItemInfos;

            await ETTask.CompletedTask;
        }
    }
}