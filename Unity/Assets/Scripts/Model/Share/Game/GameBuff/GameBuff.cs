using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [ChildOf]
    public class GameBuff : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        public long RemainderTime;

        [BsonIgnore]
        public BuffConfig Config => BuffConfigCategory.Instance.Get(this.ConfigId);
    }
}