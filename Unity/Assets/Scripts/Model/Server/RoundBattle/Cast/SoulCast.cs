using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(SoulCastComponent))]
    public class SoulCast : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        [BsonIgnore]
        public SoulCastConfig Config => SoulCastConfigCategory.Instance.Get(this.ConfigId);

        [BsonIgnore]
        public EntityRef<Soul> Caster;

        [BsonIgnore]
        public List<EntityRef<Soul>> Targets = new();
    }
}