namespace ET.Server
{
    [UnitCacheEvent(typeof(LevelComponent))]
    [ComponentOf(typeof(Unit))]
    public class LevelComponent : Entity, IAwake<int>, IUnitCache, IDestroy, ITransfer
    {
        public int Level;
        public long Exp;
    }
}