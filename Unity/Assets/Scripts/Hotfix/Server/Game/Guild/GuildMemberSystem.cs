namespace ET.Server
{
    [EntitySystemOf(typeof(GuildMember))]
    [FriendOf(typeof(GuildMember))]
    public static partial class GuildMemberSystem
    {
        [EntitySystem]
        private static void Awake(this GuildMember self)
        {
        }

        public static GuildMemberInfo ToMessage(this GuildMember self)
        {
            GuildMemberInfo info = GuildMemberInfo.Create();
            info.UnitId = self.UnitId;
            info.GuildMemberType = self.GuildMemberType;
            info.OnlineStatus = self.OnlineStatus;
            info.OfflineTime = self.OfflineTime;

            return info;
        }
    }
}