using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class GameItem : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;
        public long Amount;
        
        [BsonIgnore]
        public ItemConfig Config => ItemConfigCategory.Instance.Get(this.ConfigId);
    }
}