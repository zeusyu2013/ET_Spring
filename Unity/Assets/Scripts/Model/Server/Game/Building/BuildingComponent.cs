using System.Collections.Generic;

namespace ET.Server
{
    [UnitCacheEvent(typeof(BuildingComponent))]
    [ComponentOf(typeof(Unit))]
    public class BuildingComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public long LastProduceTime;
        
        public List<EntityRef<Building>> Buildings = new();
    }
}