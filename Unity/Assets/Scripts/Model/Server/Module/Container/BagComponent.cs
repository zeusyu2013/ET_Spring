using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class BagComponent : Entity, IAwake, ISerializeToEntity
    {
        public long PlayerId;

        public List<ItemInfo> ItemInfos;
    }
}