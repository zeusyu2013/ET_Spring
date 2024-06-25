namespace ET.Server
{
    [MessageSessionHandler(SceneType.Gate)]
    [FriendOfAttribute(typeof(ET.Server.UnitPlayerIdComponent))]
    [FriendOfAttribute(typeof(ET.Server.GameRoleComponent))]
    public class C2G_EnterMapHandler : MessageSessionHandler<C2G_EnterMap, G2C_EnterMap>
    {
        protected override async ETTask Run(Session session, C2G_EnterMap request, G2C_EnterMap response)
        {
            Player player = session.GetComponent<SessionPlayerComponent>().Player;

            long unitId = request.UnitId;

            // 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
            GateMapComponent gateMapComponent = player.GetComponent<GateMapComponent>();
            if (gateMapComponent == null)
            {
                gateMapComponent = player.AddComponent<GateMapComponent>();
                gateMapComponent.Scene =
                        await GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");
            }

            GateUnitComponent unitComponent = player.GetComponent<GateUnitComponent>();
            if (unitComponent == null)
            {
                unitComponent = player.AddComponent<GateUnitComponent>();
            }

            unitComponent.UnitId = unitId;

            Scene scene = gateMapComponent.Scene;

            // 从DBCache中获取组件信息
            Unit unit = await UnitFactory.LoadFromDB(scene, unitId);
            if (unit == null)
            {
                unit = UnitFactory.CreateCharacter(scene, unitId, CharacterType.CharacterType_Warrior, RaceType.RaceType_Human);
            }

            unit.AddComponent<UnitPlayerIdComponent>().PlayerId = player.Id;
            session.GetComponent<GameRoleComponent>().UnitId = unit.Id;
            
            TDUserAdd userAdd = TDUserAdd.Create();
            userAdd.AccountId = player.Id.ToString();
            userAdd.Properties = "";
            TDHelper.SendUserAddToTDLog(scene, userAdd);

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Map1");

            // 等到一帧的最后面再传送，先让G2C_EnterMap返回，否则传送消息可能比G2C_EnterMap还早
            TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();
        }
    }
}