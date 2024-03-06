using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf]
    public class GameRoleInfoComponent : Entity, IAwake
    {
        public List<GameRoleInfo> GameRoleInfos = new();
    }
}