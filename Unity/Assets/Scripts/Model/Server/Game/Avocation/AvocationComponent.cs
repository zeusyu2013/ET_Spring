using System.Collections.Generic;

namespace ET.Server
{
    [UnitCacheEvent(typeof(AvocationComponent))]
    [ComponentOf(typeof(Unit))]
    public class AvocationComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public Dictionary<AvocationType, EntityRef<Avocation>> Avocations = new();
    }
}