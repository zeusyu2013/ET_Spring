using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf]
    public class RequestHallComponent : Entity, IAwake, IDeserialize
    {
        [BsonIgnore]
        public Dictionary<long, List<EntityRef<GameRequest>>> GameRequests = new();
    }
}