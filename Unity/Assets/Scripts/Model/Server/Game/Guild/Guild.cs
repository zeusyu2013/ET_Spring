using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof(GuildComponent))]
    public class Guild : Entity, IAwake, ISerializeToEntity
    {
        public long GuildId;

        public string GuildName;

        public List<EntityRef<GuildMember>> GuildMembers = new();
    }
}