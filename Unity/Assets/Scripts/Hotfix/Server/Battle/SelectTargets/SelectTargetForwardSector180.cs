using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_ForwardSector180)]
    public class SelectTargetForwardSector180 : ASelectTargetHandler
    {
        public override int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            ForwardSector180 forwardSector180 = (ForwardSector180)selectTargetsParams;

            int count = forwardSector180.Count;
            if (count < 1)
            {
                return ErrorCode.ERR_CastTargetCounterLessThan1;
            }
            
            targets.Clear();

            int hitCount = 0;
            foreach (EntityRef<AOIEntity> entityRef in caster.GetSeeUnits().Values)
            {
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

                float distance = math.distance(caster.Position, target.Position);
                if (distance > forwardSector180.Radius)
                {
                    continue;
                }
                
                float3 dir = math.normalize(caster.Position - target.Position);
                float dot = math.dot(dir, caster.Forward);
                if (dot > 90)
                {
                    continue;
                }

                if (hitCount >= count)
                {
                    break;
                }

                hitCount += 1;
                
                targets.Add(target.Id);
            }

            return ErrorCode.ERR_Success;
        }
    }
}