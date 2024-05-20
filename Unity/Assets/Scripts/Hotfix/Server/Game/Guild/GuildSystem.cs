namespace ET.Server
{
    [EntitySystemOf(typeof(Guild))]
    [FriendOfAttribute(typeof(ET.Server.Guild))]
    public static partial class GuildSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Guild self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Guild self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this Guild self)
        {
            foreach (var child in self.Children.Values)
            {
                GuildMember member = child as GuildMember;
                self.GuildMembers.Add(member);
            }
        }

        public static GuildInfo ToMessage(this Guild self)
        {
            GuildInfo info = GuildInfo.Create();
            info.GuildName = self.GuildName;
            info.GuildLevel = self.GuildLevel;
            info.GuildMemberCount = self.GuildMemberCount;
            
            return info;
        }
    }
}