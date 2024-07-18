using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    [UnitCacheEvent(typeof(LearnSkillComponent))]
    public class LearnSkillComponent : Entity, IAwake, ITransfer
    {
        public List<int> LearnedSkills = new();
    }
}