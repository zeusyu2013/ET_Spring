using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BulletComponent : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId = default;

        [BsonIgnore]
        public BulletConfig Config => BulletConfigCategory.Instance.Get(this.ConfigId);

        public int TickCount = default;

        public List<long> Targets = new();

        public long OwnerId = default;

        public long TickTimer = default;
        
        public long TickTimer2 = default;
        
        public long TickTimer3 = default;
        
        public long TotalTimer = default;
    }
}