using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public class SelectTargetSelfRound : ASelectTargetHandler
    {
        public override int Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig, ref List<Unit> targets)
        {
            if (skillConfig.SkillRange != SkillRange.SkillRange_SelfRound)
            {
                return ErrorCode.ERR_SkillRangeNotMatch;
            }

            SkillTargetCycle cycle = (SkillTargetCycle)skillConfig.SkillTargetRangeParam;

            Unit unit = selectTargetComponent.GetParent<Unit>();

            if (cycle.IncludeSelf)
            {
                targets.Add(unit);
            }

            foreach (EntityRef<AOIEntity> entityRef in unit.GetSeeUnits().Values)
            {
                AOIEntity aoiEntity = entityRef;
                Unit target = aoiEntity.GetParent<Unit>();
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                if (math.distance(unit.Position, target.Position) > cycle.Radius)
                {
                    continue;
                }

                targets.Add(target);
            }

            return ErrorCode.ERR_Success;
        }
    }
}