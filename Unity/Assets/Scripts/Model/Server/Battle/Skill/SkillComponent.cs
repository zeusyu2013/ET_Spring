using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake, IDestroy
    {
        public List<int> Skills = new();
    }
}