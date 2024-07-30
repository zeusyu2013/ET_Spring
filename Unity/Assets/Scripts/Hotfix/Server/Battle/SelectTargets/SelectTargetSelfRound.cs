using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public class SelectTargetSelfRound : ASelectTargetHandler
    {
        public override int Check(SelectTargetComponent selectTargetComponent, CastConfig castConfig, ref List<long> targets)
        {
            if (castConfig.SelectTargetType != SelectTargetType.SelectTargetType_Cycle)
            {
                return ErrorCode.ERR_CastTargetTypeNotMatch;
            }

            CastTargetCycle cycle = (CastTargetCycle)castConfig.CastSelectTargetsParam;

            int counter = cycle.Counter;
            if (counter < 1)
            {
                return ErrorCode.ERR_CastTargetCounterLessThan1;
            }

            Unit unit = selectTargetComponent.GetParent<Unit>();
            if (cycle.IncludeSelf)
            {
                counter -= 1;
                targets.Add(unit.Id);
            }
            
            foreach (EntityRef<AOIEntity> entityRef in unit.GetSeeUnits().Values)
            {
                if (counter < 1)
                {
                    break;
                }

                AOIEntity aoiEntity = entityRef;
                Unit target = aoiEntity.GetParent<Unit>();
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                if (math.length(unit.Position - target.Position) > cycle.Radius)
                {
                    continue;
                }

                counter -= 1;
                targets.Add(target.Id);
            }

            return ErrorCode.ERR_Success;
        }
    }
}