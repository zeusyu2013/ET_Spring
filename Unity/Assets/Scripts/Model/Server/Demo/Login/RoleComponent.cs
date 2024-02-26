using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class RoleComponent : Entity, IAwake, IDestroy
    {
        public List<EntityRef<RoleInfo>> RoleInfos = new();
    }
}