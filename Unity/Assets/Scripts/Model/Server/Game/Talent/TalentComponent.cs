using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [UnitCacheEvent(typeof(TalentComponent))]
    [ComponentOf(typeof(Unit))]
    public class TalentComponent : Entity, IAwake, IDestroy, IDeserialize
    {
        public int TalentPoint;

        [BsonIgnore]
        public List<EntityRef<Talent>> Talents = new();
    }
}