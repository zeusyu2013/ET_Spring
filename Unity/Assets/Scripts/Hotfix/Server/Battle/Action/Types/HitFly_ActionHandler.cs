using Unity.Mathematics;

namespace ET.Server
{
    [Action(ActionType.ActionType_HitFly)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    [FriendOf(typeof(Buff))]
    public class HitFly_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Unit caster = null;

            switch (type)
            {
                case ActionTriggerType.BuffTick:
                    caster = action.Buff.Owner;
                    break;

                case ActionTriggerType.CastHit:
                    caster = action.Cast.Caster;
                    break;
            }

            ActionConfig config = action.Config;
            HitFlyParams hitFlyParams = (HitFlyParams)config.ActionParams;
            if (hitFlyParams == null)
            {
                return;
            }

            float range = hitFlyParams.Range;
            float dir = hitFlyParams.Direction;
            int buffConfigId = hitFlyParams.BuffConfigId;

            foreach (var value in caster.GetBeSeeUnits().Values)
            {
                AOIEntity aoiEntity = value;
                Unit target = aoiEntity.GetParent<Unit>();

                if (target.Type() != UnitType.UnitType_Player || target.Type() != UnitType.UnitType_Monster)
                {
                    continue;
                }

                if (caster == target)
                {
                    continue;
                }

                if (math.length(target.Position - caster.Position) < range)
                {
                    float3 targetPos = new float3(target.Position.x, 0, target.Position.z);
                    float3 casterPos = new float3(caster.Position.x, 0, caster.Position.z);
                    float3 targetDir = math.normalize(targetPos - casterPos);
                    float3 forwardDir = caster.Forward;
                    forwardDir.y = 0;

                    float3 newPos = targetPos + (forwardDir * dir);

                    target.FindPathMoveToAsync(newPos).Coroutine();

                    if (buffConfigId != 0)
                    {
                        target.GetComponent<BuffComponent>().CreateAndAdd(buffConfigId);
                    }
                }
            }
        }
    }
}