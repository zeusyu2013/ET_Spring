using System.Collections.Generic;

namespace ET
{
    public class SelectTargetSingle : ASelectTargetHandler
    {
        public override (int, List<Unit>) Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig)
        {
            List<Unit> units = new();

            if (skillConfig.SkillRange != SkillRange.SkillRange_Single)
            {
                return (SelectTargetErrorCode.ERR_SkillRangeNotMatch, units);
            }
            
            return (SelectTargetErrorCode.ERR_Success, units);
        }
    }
}