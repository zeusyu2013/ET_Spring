using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ComponentOf]
    public class GuildComponent : Entity, IAwake, IDeserialize
    {
        [BsonIgnore]
        public Dictionary<string, EntityRef<Guild>> Guilds = new();
    }
}