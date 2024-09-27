using System.Collections.Generic;

namespace ET.Server
{
    [UnitCacheEvent(typeof(SoulComponent))]
    [ComponentOf(typeof(Unit))]
    public class SoulComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer
    {
        public Dictionary<int, int> Battles = new();
    }
}