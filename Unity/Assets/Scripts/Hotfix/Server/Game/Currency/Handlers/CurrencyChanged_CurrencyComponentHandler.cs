using System;

namespace ET.Server
{
    [Serializable]
    public struct TDTrackCurrencyChanged
    {
        public int currencyType;
        public int currencyChangeType;
        public long oldValue;
        public long newValue;
        public string changeReason;
    }

    [Event(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.UnitPlayerIdComponent))]
    public class CurrencyChanged_CurrencyComponentHandler : AEvent<Scene, CurrencyChanged>
    {
        protected override async ETTask Run(Scene scene, CurrencyChanged args)
        {
            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            TDTrack track = TDTrack.Create();
            track.AccountId = unit.GetComponent<UnitPlayerIdComponent>().PlayerIdSting;
            track.EventName = "currency_changed";

            TDTrackCurrencyChanged currencyChanged = new();
            currencyChanged.currencyType = (int)args.Type;
            currencyChanged.currencyChangeType = (int)args.ChangeType;
            currencyChanged.oldValue = args.OldValue;
            currencyChanged.newValue = args.NewValue;
            currencyChanged.changeReason = args.CurrencyChangeReason;
            track.Properties = LitJson.JsonMapper.ToJson(currencyChanged);

            TDHelper.SendTrackToTDLog(scene, track);

            await ETTask.CompletedTask;
        }
    }
}