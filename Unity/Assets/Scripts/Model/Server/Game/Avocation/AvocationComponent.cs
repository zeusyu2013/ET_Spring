using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AvocationComponent : Entity, IAwake, IDeserialize
    {
        public Dictionary<AvocationType, EntityRef<Avocation>> Avocations = new();
    }
}