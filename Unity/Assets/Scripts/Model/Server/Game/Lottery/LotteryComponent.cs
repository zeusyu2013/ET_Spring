namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(LotteryComponent))]
    public class LotteryComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public int Level;
    }
}