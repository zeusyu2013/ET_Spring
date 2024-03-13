namespace ET.Server
{
    [ChildOf]
    public class GameItem : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;
        public long Amount;
        public ItemConfig Config => ItemConfigCategory.Instance.Get(this.ConfigId);
    }
}