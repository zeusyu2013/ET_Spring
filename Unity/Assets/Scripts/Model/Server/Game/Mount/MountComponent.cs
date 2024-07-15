using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(MountComponent))]
    public class MountComponent : Entity, IAwake, IDestroy, ITransfer, IDeserialize
    {
        public int MountConfig;
        
        public List<int> Mounts = new();
    }
}