using System.Collections.Generic;

namespace ET.Server
{
    [UnitCacheEvent(typeof(TransmogrificationComponent))]
    [ComponentOf]
    public class TransmogrificationComponent: Entity, IAwake, IDestroy, IUnitCache, ITransfer
    {
        public List<int> Transmogrifications = new();
    }
}