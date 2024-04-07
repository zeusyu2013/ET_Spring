using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class GuildComponent : Entity, IAwake, IDeserialize
    {
        public Dictionary<long, EntityRef<Guild>> Guilds = new();
    }
}