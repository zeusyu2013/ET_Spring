using System.Collections.Generic;

namespace ET.Server
{
    public class Guild : Entity, IAwake
    {
        public long GuildId;

        public string GuildName;

        public List<EntityRef<GuildMember>> GuildMembers = new();
    }
}