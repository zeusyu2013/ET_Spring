using System.Collections.Generic;

namespace ET
{
    public class RoleComponent : Entity, IAwake, IDestroy
    {
        public List<EntityRef<RoleInfo>> RoleInfos = new();
    }
}