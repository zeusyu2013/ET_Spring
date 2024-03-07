namespace ET
{
    [ChildOf]
    public class GameItem : Entity, IAwake<int>, ISerializeToEntity
    {
        public int ItemConfig;
        public long ItemCount;
    }
}