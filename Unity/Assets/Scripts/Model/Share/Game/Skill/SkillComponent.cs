using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake, IDestroy
    {
        public List<int> Skills = new();
    }
}