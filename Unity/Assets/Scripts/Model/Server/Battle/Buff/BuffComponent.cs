using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    [UnitCacheEvent(typeof(BuffComponent))]
    public class BuffComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
        [BsonIgnore]
        public Dictionary<int, EntityRef<Buff>> Buffs = new();
    }
}