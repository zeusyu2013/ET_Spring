using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    [UnitCacheEvent(typeof(GameBuffComponent))]
    public class GameBuffComponent : Entity, IAwake, IUpdate, IDestroy, ITransfer, IDeserialize
    {
        [BsonIgnore]
        public List<EntityRef<GameBuff>> GameBuffs = new();
    }
}