using System.Collections.Generic;

namespace ET.Client
{
    [ChildOf(typeof(ClientCastComponent))]
    public class ClientCast : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public CastConfig Config => CastConfigCategory.Instance.Get(this.ConfigId);

        public long CasterId;

        public List<long> Targets = new();
    }
}