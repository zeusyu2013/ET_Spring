using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf]
    public class ClientCastComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<ClientCast>> Casts = new();
    }
}