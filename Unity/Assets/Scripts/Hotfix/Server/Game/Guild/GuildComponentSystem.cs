using System.Collections.Generic;

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

        [EntitySystem]
        private static void Deserialize(this ET.Server.GuildComponent self)
        {
            foreach (Entity childrenValue in self.Children.Values)
            {
                Guild guild = childrenValue as Guild;
                self.Guilds.Add(guild.GuildName, guild);
            }
        }

        public static List<GuildInfo> GetAllGuilds(this GuildComponent self)
        {
            List<GuildInfo> infos = new();

            if (self.Guilds.Count < 1)
            {
                return infos;
            }

            foreach (var guildRef in self.Guilds.Values)
            {
                Guild guild = guildRef;
                infos.Add(guild.ToMessage());
            }

            return infos;
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

        public static int CreateGuild(this GuildComponent self, string guildName, long unitId)
        {
            if (string.IsNullOrEmpty(guildName))
            {
                return ErrorCode.ERR_GuildEmpty;
            }

            if (self.IsPlayerInGuild(unitId))
            {
                return ErrorCode.ERR_AlreadyHasGuild;
            }

            if (self.Guilds.ContainsKey(guildName))
            {
                return ErrorCode.ERR_GuildNameSame;
            }

            Guild guild = self.AddChild<Guild>();
            guild.GuildName = guildName;
            guild.GuildLevel = 1;

            GuildMember member = guild.AddChild<GuildMember>();
            member.UnitId = unitId;
            member.GuildMemberType = 1;
            member.OnlineStatus = 1;
            member.OfflineTime = 0;

            guild.GuildMembers.Add(member);

            self.Guilds.Add(guild.GuildName, guild);

            return ErrorCode.ERR_Success;
        }

        public static int JoinGuild(this GuildComponent self, string guildName, long unitId)
        {
            if (string.IsNullOrEmpty(guildName))
            {
                return ErrorCode.ERR_GuildEmpty;
            }

            if (self.IsPlayerInGuild(unitId))
            {
                return ErrorCode.ERR_AlreadyHasGuild;
            }

            if (!self.Guilds.ContainsKey(guildName))
            {
                return ErrorCode.ERR_NotFoundGuild;
            }

            Guild guild = self.Guilds[guildName];
            GuildMember member = guild.AddChild<GuildMember>();
            member.UnitId = unitId;
            member.GuildMemberType = 2;
            member.OnlineStatus = 1;
            member.OfflineTime = 0;
            guild.GuildMembers.Add(member);

            return ErrorCode.ERR_Success;
        }

        public static int QuitGuild(this GuildComponent self, string guildName, long unitId)
        {
            if (string.IsNullOrEmpty(guildName))
            {
                return ErrorCode.ERR_GuildEmpty;
            }

            if (!self.IsPlayerInGuild(unitId))
            {
                return ErrorCode.ERR_PlayerNotHasGuild;
            }

            if (!self.Guilds.ContainsKey(guildName))
            {
                return ErrorCode.ERR_NotFoundGuild;
            }

            Guild guild = self.Guilds[guildName];
            GuildMember member = guild.GuildMembers.Find(x => ((GuildMember)x).UnitId == unitId);
            if (member == null)
            {
                return ErrorCode.ERR_PlayerNotHasGuild;
            }

            guild.GuildMembers.Remove(member);
            guild.RemoveChild(member.Id);

            return ErrorCode.ERR_Success;
        }
    }
}