using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class GameTaskComponent : Entity, IAwake, ISerializeToEntity
    {
        [BsonElement]
        public List<int> AcceptedTasks = new();
        
        [BsonElement]
        public List<int> CompletedTasks = new();
    }
}