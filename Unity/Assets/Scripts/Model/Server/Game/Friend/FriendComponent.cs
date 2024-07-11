using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(FriendComponent))]
    public class FriendComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
        [BsonIgnore]
        public Dictionary<long, EntityRef<Friend>> Friends = new();
    }
}