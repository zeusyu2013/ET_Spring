using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BulletComponent : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        [BsonIgnore]
        public BulletConfig Config => BulletConfigCategory.Instance.Get(this.ConfigId);

        public long OwnerId;

        public long TickTimer;
    }
}