using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class TeamHallComponent : Entity, IAwake, IDestroy
    {
        public List<long> TeamMembers = new();
    }
}