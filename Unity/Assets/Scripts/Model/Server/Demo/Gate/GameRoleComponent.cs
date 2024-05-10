using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Session))]
    public class GameRoleComponent : Entity, IAwake, IDeserialize
    {
        public List<EntityRef<GameRole>> GameRoles = new();
    }
}