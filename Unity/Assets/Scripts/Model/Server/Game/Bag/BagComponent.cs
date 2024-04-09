using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, IGetComponentSys, ISerializeToEntity, IDeserialize
    {
        public int Capacity;

        public int MaxCapacity;
        
        public List<EntityRef<GameItem>> GameItems = new();
    }
}