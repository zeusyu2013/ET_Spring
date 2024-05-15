using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [UnitCacheEvent(typeof(BagComponent))]
    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer, IUnitCache
    {
        public int Capacity;

        public int MaxCapacity;
        
        [BsonIgnore]
        public List<EntityRef<GameItem>> GameItems = new();
    }
}