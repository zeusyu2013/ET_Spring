namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(VipComponent))]
    public class VipComponent : Entity, IAwake, ITransfer
    {
        public int VipLevel;
        public long VipExp;
    }
}