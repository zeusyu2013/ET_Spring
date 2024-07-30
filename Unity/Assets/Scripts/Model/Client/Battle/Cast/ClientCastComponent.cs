using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class ClientCastComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<ClientCast>> Casts = new();
    }
}