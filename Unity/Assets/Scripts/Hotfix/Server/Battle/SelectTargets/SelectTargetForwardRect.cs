using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_ForwardRect)]
    public class SelectTargetForwardRect : ASelectTargetHandler
    {
        public override int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            ForwardRect rect = (ForwardRect)selectTargetsParams;

            int counter = rect.Counter;
            if (counter < 1)
            {
                return ErrorCode.ERR_CastTargetCounterLessThan1;
            }
            
            targets.Clear();
            
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

                float3 dir = math.normalize(caster.Position - target.Position);
                float dot = math.dot(dir, caster.Forward);
                if (dot > 90)
                {
                    continue;
                }

                float distance = math.distance(target.Position, caster.Position);
                float z = distance * math.cos(dot * math.PI * 2 / 360);
                float x = distance * math.sin(dot * math.PI * 2 / 360);
                if (x > rect.Width * 0.5f || z > rect.Height)
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