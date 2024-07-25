using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf]
    public class GameBuff : Entity, IAwake<int>, IDestroy, ISerializeToEntity
    {
        public int ConfigId;

        public long StartTime;
        
        public long RemainderTime;

        public long Timer;

        [BsonIgnore]
        public BuffConfig Config => BuffConfigCategory.Instance.Get(this.ConfigId);
    }
}