namespace ET.Server
{
    [Event(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.UnitPlayerIdComponent))]
    public class BagOnRemove_BagComponent_TDHandler : AEvent<Scene, BagOnRemove>
    {
        protected override async ETTask Run(Scene scene, BagOnRemove args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            TDTrack track = TDTrack.Create();
            track.AccountId = unit.GetComponent<UnitPlayerIdComponent>().PlayerIdSting;

            TDTrackGameItemChanged change = new();
            change.GameItemConfig = args.GameItemConfig;
            change.OldAmount = args.OldAmount;
            change.NewAmount = args.NewAmount;
            track.Properties = LitJson.JsonMapper.ToJson(change);

            TDHelper.SendTrackToTDLog(scene, track);

            await ETTask.CompletedTask;
        }
    }
}