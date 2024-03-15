using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, ISerializeToEntity
    {
        public long PlayerId;

        public int Capacity;

        public int MaxCapacity;
        
        public List<ItemInfo> ItemInfos;
    }
}