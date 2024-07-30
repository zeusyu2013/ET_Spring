using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    [UnitCacheEvent(typeof(BuffComponent))]
    public class BuffComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
        public Dictionary<int, EntityRef<Buff>> Buffs = new();
    }
}