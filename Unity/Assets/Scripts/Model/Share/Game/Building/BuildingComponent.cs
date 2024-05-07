using System.Collections.Generic;

namespace ET
{
    public class BuildingComponent : Entity, IAwake, IDeserialize
    {
        public List<EntityRef<Building>> Buildings = new();
    }
}