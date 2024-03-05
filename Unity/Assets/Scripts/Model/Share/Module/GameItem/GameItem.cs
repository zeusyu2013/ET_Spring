namespace ET
{
    [ChildOf]
    public class GameItem : Entity, IAwake<int>
    {
        public int ItemConfig;
        public long ItemCount;
    }
}