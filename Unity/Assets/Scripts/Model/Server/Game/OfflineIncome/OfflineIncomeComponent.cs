namespace ET.Server
{
    [UnitCacheEvent(typeof(OfflineIncomeComponent))]
    [ComponentOf(typeof(Unit))]
    public class OfflineIncomeComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public long LastIncomeTime;
    }
}