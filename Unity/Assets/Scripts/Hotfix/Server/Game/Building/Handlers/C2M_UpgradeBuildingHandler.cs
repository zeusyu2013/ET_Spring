namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(Building))]
    public class C2M_UpgradeBuildingHandler : MessageLocationHandler<Unit, C2M_UpgradeBuilding, M2C_UpgradeBuilding>
    {
        protected override async ETTask Run(Unit unit, C2M_UpgradeBuilding request, M2C_UpgradeBuilding response)
        {
            unit.GetComponent<BuildingComponent>().UpgradeBuilding(request.BuildingConfig);

            await ETTask.CompletedTask;
        }
    }
}