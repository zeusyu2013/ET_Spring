namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class OfflineIncomeComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public long LastIncomeTime;
    }
}