using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class BuildingComponent : Entity, IAwake, IDeserialize
    {
        public List<EntityRef<Building>> Buildings = new();
    }
}