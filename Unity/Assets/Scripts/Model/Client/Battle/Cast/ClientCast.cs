using System.Collections.Generic;

namespace ET.Client
{
    [ChildOf]
    public class ClientCast : Entity, IAwake<int>, IDestroy
    {
        public int ConfigId;

        public long CasterId;

        public List<long> Targets = new();
    }
}