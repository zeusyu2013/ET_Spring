namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class OfflineIncomeComponent : Entity, IAwake, ISerializeToEntity
    {
        public long LastIncomeTime;
    }
}