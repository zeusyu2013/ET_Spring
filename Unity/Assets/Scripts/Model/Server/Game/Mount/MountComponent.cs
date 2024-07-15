using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(MountComponent))]
    public class MountComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public int MountConfigId;
        
        public List<int> Mounts = new();
    }
}