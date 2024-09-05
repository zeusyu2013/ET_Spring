using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Soul))]
    public class SoulTalentComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        public List<int> SoulTalents = new();
    }
}