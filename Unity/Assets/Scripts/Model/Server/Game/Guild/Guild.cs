using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(GuildComponent))]
    public class Guild : Entity, IAwake, ISerializeToEntity, IDestroy, IDeserialize
    {
        public long GuildId;

        public string GuildName;

        public int GuildLevel;

        public int GuildMemberCount => this.GuildMembers.Count;

        [BsonIgnore]
        public List<EntityRef<GuildMember>> GuildMembers = new();
    }
}