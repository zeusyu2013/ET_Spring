using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Session))]
    public class GameRoleComponent : Entity, IAwake
    {
        public List<GameRoleInfo> GameRoles = new();
    }
}