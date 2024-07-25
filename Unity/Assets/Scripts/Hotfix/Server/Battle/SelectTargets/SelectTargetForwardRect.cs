using System.Collections.Generic;

namespace ET.Server
{
    public class SelectTargetForwardRect : ASelectTargetHandler
    {
        public override int Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig, ref List<Unit> targets)
        {
            List<Unit> units = new();
            if (skillConfig.SkillRange != SkillRange.SkillRange_Single)
            {
                return ErrorCode.ERR_SkillRangeNotMatch;
            }

            Unit unit = selectTargetComponent.GetParent<Unit>();
            targets.Add(unit);

            return ErrorCode.ERR_Success;
        }
    }
}