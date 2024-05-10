namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class OfflineIncomeComponent : Entity, IAwake, IDeserialize
    {
        public long LastIncomeTime;
    }
}