using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [Action(ActionType.ActionType_Attract)]
    [FriendOfAttribute(typeof(ET.Server.Action))]
    [FriendOf(typeof(BulletComponent))]
    public class Attract_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            if (type != ActionTriggerType.BulletTick)
            {
                return;
            }

            Unit caster = action.Caster;
            List<long> targets = action.BulletComponent.Targets;

            if (targets.Count < 1)
            {
                return;
            }

            AttractParams attractParams = (AttractParams)action.Config.ActionParams;
            if (attractParams == null)
            {
                return;
            }

            float range = attractParams.AttractRange;
            float speed = attractParams.AttractSpeed;

            UnitComponent unitComponent = action.Scene().GetComponent<UnitComponent>();

            foreach (long id in targets)
            {
                Unit target = unitComponent.Get(id);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                if (math.distance(target.Position, caster.Position) > range)
                {
                    continue;
                }

                float3 newPosition = target.Position + math.normalize(caster.Position - target.Position) * speed;

                target.ForceSetPosition(newPosition, true);

                Log.Console($"吸引目标 {id} 新位置 {newPosition}");
            }
        }
    }
}