using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_Cycle)]
    public class SelectTargetSelfRound : ASelectTargetHandler
    {
        public override int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            Cycle cycle = (Cycle)selectTargetsParams;

            int counter = cycle.Counter;
            if (counter < 1)
            {
                return ErrorCode.ERR_CastTargetCounterLessThan1;
            }

            if (cycle.IncludeSelf)
            {
                counter -= 1;
                targets.Add(caster.Id);
            }

            foreach (EntityRef<AOIEntity> entityRef in caster.GetSeeUnits().Values)
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

                if (target.Type() != UnitType.UnitType_Player && target.Type() != UnitType.UnitType_Monster)
                {
                    continue;
                }

                if (math.length(caster.Position - target.Position) > cycle.Radius)
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