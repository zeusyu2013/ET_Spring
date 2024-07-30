using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(BuffComponent))]
    public class Buff : Entity, IAwake<int>, IDestroy, ISerializeToEntity, IDeserialize
    {
        public int ConfigId;

        [BsonIgnore]
        public BuffConfig Config => BuffConfigCategory.Instance.Get(this.ConfigId);

        [BsonIgnore]
        public EntityRef<Unit> Owner;

        public long CreateTime;

        public int TickTime;

        public long TickBeginTime;

        [BsonIgnore]
        public long TickTimer;

        [BsonIgnore]
        public long WaitTickTimer;

        public long ExpiredTime;

        [BsonIgnore]
        public long ExpiredTimer;
    }
}