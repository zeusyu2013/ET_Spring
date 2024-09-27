using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Soul))]
    public class SoulBuffComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, EntityRef<SoulBuff>> Buffs = new();
    }
}