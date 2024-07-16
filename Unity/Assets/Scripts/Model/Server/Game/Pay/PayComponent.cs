namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(PayComponent))]
    public class PayComponent : Entity, IAwake, ITransfer
    {
        public long PayAmount;
    }
}