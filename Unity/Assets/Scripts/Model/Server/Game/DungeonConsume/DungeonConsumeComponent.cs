namespace ET.Server
{
    [UnitCacheEvent(typeof(DungeonConsumeComponent))]
    [ComponentOf(typeof(Unit))]
    public class DungeonConsumeComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
        public int Consume;

        public int ConsumeMax;

        public long ConsumeRecoverTime;

        public long ConsumeTimer;
    }
}