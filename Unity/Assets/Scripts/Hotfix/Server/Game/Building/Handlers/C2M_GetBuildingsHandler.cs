namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.BuildingComponent))]
    public class C2M_GetBuildingsHandler : MessageLocationHandler<Unit, C2M_GetBuildings, M2C_GetBuildings>
    {
        protected override async ETTask Run(Unit unit, C2M_GetBuildings request, M2C_GetBuildings response)
        {
            BuildingComponent buildingComponent = unit.GetComponent<BuildingComponent>();
            if (buildingComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFountComponent;
                response.Message = "没找到建筑组件";
                return;
            }

            response.Buildings.Clear();
            foreach (var entityRef in buildingComponent.Buildings)
            {
                Building building = entityRef;
                response.Buildings.Add(building.ToMessage());
            }

            await ETTask.CompletedTask;
        }
    }
}