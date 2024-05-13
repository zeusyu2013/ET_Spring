using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, IDeserialize, ITransfer, IUnitCache, IGetComponentSys
    {
        public int Capacity;

        public int MaxCapacity;
        
        [BsonIgnore]
        public List<EntityRef<GameItem>> GameItems = new();
    }
}