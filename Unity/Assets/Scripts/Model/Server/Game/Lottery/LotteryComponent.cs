namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(LotteryComponent))]
    public class LotteryComponent : Entity, IAwake, IDestroy
    {
        public int Level;
    }
}