using System.Collections.Generic;

namespace ET
{
    public class SelectTargetSelfRound : ASelectTargetHandler
    {
        public override (int, List<Unit>) Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig)
        {
            List<Unit> units = new();
            
            return (0, units);
        }
    }
}