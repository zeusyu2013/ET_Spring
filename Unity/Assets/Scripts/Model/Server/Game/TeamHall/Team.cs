using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf]
    public class Team : Entity, IAwake, IDestroy
    {
        public long TeamId;
        public long TeamLeaderId;
        public List<long> TeamMemberIds;
    }
}