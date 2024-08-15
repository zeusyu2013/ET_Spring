using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(TeamHallComponent))]
    [FriendOfAttribute(typeof(ET.Server.TeamHallComponent))]
    [FriendOfAttribute(typeof(ET.Server.Team))]
    [FriendOfAttribute(typeof(ET.Server.TeamTag))]
    public static partial class TeamHallComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.TeamHallComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.TeamHallComponent self)
        {
        }

        public static TeamInfo GetTeam(this TeamHallComponent self, long teamId)
        {
            if (self.Children.TryGetValue(teamId, out Entity team))
            {
                return ((Team)team).ToMessage();
            }

            return null;
        }

        public static List<TeamInfo> GetTeams(this TeamHallComponent self)
        {
            List<TeamInfo> infos = new();
            foreach ((long _, Entity value) in self.Children)
            {
                Team team = value as Team;
                if (team == null)
                {
                    continue;
                }

                infos.Add(team.ToMessage());
            }

            return infos;
        }

        public static int CreateTeam(this TeamHallComponent self, long leaderUnitId, out long teamId)
        {
            bool hasTeam = self.TeamMembers.Contains(leaderUnitId);
            if (hasTeam)
            {
                teamId = 0;
                return ErrorCode.ERR_AlreadyHasTeam;
            }

            Team team = self.AddChild<Team>();
            team.TeamId = team.Id;
            team.TeamLeaderId = leaderUnitId;
            team.TeamMemberIds = new();

            self.TeamMembers.Add(leaderUnitId);

            teamId = team.TeamId;

            return ErrorCode.ERR_Success;
        }

        public static int JoinTeam(this TeamHallComponent self, long teamId, long unitId)
        {
            bool hasTeam = self.TeamMembers.Contains(unitId);
            if (hasTeam)
            {
                return ErrorCode.ERR_AlreadyHasTeam;
            }

            Team team = self.GetChild<Team>(teamId);
            if (team == null)
            {
                return ErrorCode.ERR_NotFoundTeam;
            }

            if (team.TeamMemberIds.Count >= GlobalDataConfigCategory.Instance.TeamMemberLimit)
            {
                return ErrorCode.ERR_TeamMemberFull;
            }

            team.TeamMemberIds.Add(unitId);

            self.TeamMembers.Add(unitId);

            return ErrorCode.ERR_Success;
        }

        public static int QuitTeam(this TeamHallComponent self, long teamId, long unitId)
        {
            bool hasTeam = self.TeamMembers.Contains(unitId);
            if (!hasTeam)
            {
                return ErrorCode.ERR_NotFoundTeam;
            }

            Team team = self.GetChild<Team>(teamId);
            if (team == null)
            {
                return ErrorCode.ERR_NotFoundTeam;
            }

            // 队长
            if (team.TeamLeaderId == unitId)
            {
                if (team.TeamMemberIds.Count > 0)
                {
                    team.TeamLeaderId = team.TeamMemberIds[0];
                }
                else
                {
                    team.Dispose();
                }
            }
            // 队员
            else
            {
                team.TeamMemberIds.Remove(unitId);
            }

            self.TeamMembers.Remove(unitId);

            return ErrorCode.ERR_Success;
        }
    }
}