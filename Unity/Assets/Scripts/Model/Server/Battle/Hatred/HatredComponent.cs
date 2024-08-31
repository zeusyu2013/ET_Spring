using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class HatredComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, long> Hatreds = new();
    }
}