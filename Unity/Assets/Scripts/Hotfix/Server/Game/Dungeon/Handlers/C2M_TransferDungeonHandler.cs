namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.LocationComponent))]
    public class C2M_TransferDungeonHandler : MessageLocationHandler<Unit, C2M_TransferDungeon, M2C_TransferDungeon>
    {
        protected override async ETTask Run(Unit unit, C2M_TransferDungeon request, M2C_TransferDungeon response)
        {
            ActorId actorId = request.ActorId;
            if (actorId.Equals(new ActorId()))
            {
                response.Error = ErrorCode.ERR_TransferDungeonFailed;
                return;
            }

            LocationComponent locationComponent = unit.GetComponent<LocationComponent>();
            locationComponent.SceneName = unit.Root().Name;
            locationComponent.Position = unit.Position;
            locationComponent.Rotation = unit.Rotation;

            await TransferHelper.TransferAtFrameFinish(unit, actorId, "");
        }
    }
}