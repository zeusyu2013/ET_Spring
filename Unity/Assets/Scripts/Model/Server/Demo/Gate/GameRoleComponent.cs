using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Session))]
    public class GameRoleComponent : Entity, IAwake, IDestroy
    {
        public List<GameRoleInfo> GameRoles = new();

        public long UnitId;
    }
}