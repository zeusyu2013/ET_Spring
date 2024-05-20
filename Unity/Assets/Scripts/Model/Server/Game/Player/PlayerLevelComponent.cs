namespace ET.Server
{
    [UnitCacheEvent(typeof(PlayerLevelComponent))]
    [ComponentOf(typeof(Unit))]
    public class PlayerLevelComponent : Entity, IAwake<int>, IUnitCache, IDestroy, ITransfer
    {
        public int Level;
        public long Exp;
        public long MaxExp;
    }
}