namespace ET.Server
{
    [UnitCacheEvent(typeof(LevelComponent))]
    [ComponentOf(typeof(Unit))]
    public class LevelComponent : Entity, IAwake<int>, IDestroy, ITransfer
    {
        public int Level;
        public long Exp;
    }
}