using System;

namespace ET.Server
{
    [Serializable]
    public struct TDTrackGameItemChanged
    {
        public int GameItemConfig;
        public long OldAmount;
        public long NewAmount;
    }

    [Event(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.UnitPlayerIdComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class BagOnAdd_BagComponent_TDHandler : AEvent<Scene, BagOnAdd>
    {
        protected override async ETTask Run(Scene scene, BagOnAdd args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            GameItem item = args.GameItem;
            if (item == null || item.IsDisposed)
            {
                return;
            }

            TDTrack track = TDTrack.Create();
            track.AccountId = unit.GetComponent<UnitPlayerIdComponent>().PlayerIdSting;

            TDTrackGameItemChanged change = new TDTrackGameItemChanged();
            change.GameItemConfig = args.GameItem.ConfigId;
            change.OldAmount = args.OldAmount;
            change.NewAmount = args.NewAmount;
            track.Properties = LitJson.JsonMapper.ToJson(change);

            TDHelper.SendTrackToTDLog(scene, track);

            await ETTask.CompletedTask;
        }
    }
}