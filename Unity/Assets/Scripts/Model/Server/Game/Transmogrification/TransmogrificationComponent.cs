using System.Collections.Generic;

namespace ET.Server
{
    [UnitCacheEvent(typeof(TransmogrificationComponent))]
    [ComponentOf]
    public class TransmogrificationComponent: Entity, IAwake, IDestroy, ITransfer
    {
        public List<int> Transmogrifications = new();
    }
}