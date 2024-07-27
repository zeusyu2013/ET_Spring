using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf]
    public class ClientBuffComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<ClientBuff>> Buffs = new();
    }
}