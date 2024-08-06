using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class TrapComponent : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId = default;

        [BsonIgnore]
        public TrapConfig Config => TrapConfigCategory.Instance.Get(this.ConfigId);

        public int TickCount = default;

        public List<long> Targets = new();

        public long OwnerId = default;

        public long TickTimer = default;

        public long TotalTimer = default;
    }
}