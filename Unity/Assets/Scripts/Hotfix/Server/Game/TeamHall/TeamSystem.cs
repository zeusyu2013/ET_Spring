namespace ET.Server
{
    [EntitySystemOf(typeof(Team))]
    [FriendOfAttribute(typeof(ET.Server.Team))]
    public static partial class TeamSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Team self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Team self)
        {
        }

        public static TeamInfo ToMessage(this Team self)
        {
            TeamInfo info = TeamInfo.Create();
            info.TeamId = self.TeamId;
            info.TeamLeaderId = self.TeamLeaderId;
            info.TeamMemberIds = self.TeamMemberIds;
            
            return info;
        }
    }
}