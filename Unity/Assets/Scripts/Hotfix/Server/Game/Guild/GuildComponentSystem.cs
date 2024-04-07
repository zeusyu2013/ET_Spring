namespace ET.Server
{
    [EntitySystemOf(typeof(GuildComponent))]
    [FriendOfAttribute(typeof(ET.Server.GuildComponent))]
    [FriendOfAttribute(typeof(ET.Server.Guild))]
    [FriendOfAttribute(typeof(ET.Server.GuildMember))]
    public static partial class GuildComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.GuildComponent self)
        {
        }

        public static bool IsPlayerInGuild(this GuildComponent self, long unitId)
        {
            foreach (Guild guild in self.Guilds.Values)
            {
                foreach (var guildGuildMember in guild.GuildMembers)
                {
                    GuildMember member = guildGuildMember;
                    if (member.UnitId == unitId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.GuildComponent self)
        {
            foreach (Entity childrenValue in self.Children.Values)
            {
                Guild guild = childrenValue as Guild;
                self.Guilds.Add(childrenValue.Id, guild);
            }
        }
    }
}