namespace ET.Server
{
    [UnitCacheEvent(typeof(SevenDayComponent))]
    [ComponentOf(typeof(Unit))]
    public class SevenDayComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public int BeginDay;

        public int GetDay;
    }
}