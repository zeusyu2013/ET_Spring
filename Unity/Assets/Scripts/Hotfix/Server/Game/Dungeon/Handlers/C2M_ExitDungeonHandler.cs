namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.LocationComponent))]
    public class C2M_ExitDungeonHandler : MessageLocationHandler<Unit, C2M_ExitDungeon, M2C_ExitDungeon>
    {
        protected override async ETTask Run(Unit unit, C2M_ExitDungeon request, M2C_ExitDungeon response)
        {
            Scene scene = unit.Root();
            DungeonComponent dungeonComponent = scene.GetComponent<DungeonComponent>();
            if (dungeonComponent == null)
            {
                return;
            }

            long unitId = unit.Id;

            LocationComponent locationComponent = unit.GetComponent<LocationComponent>();

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), locationComponent.SceneName);
            await TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, "");

            dungeonComponent.ExitDungeon(unitId);
        }
    }
}