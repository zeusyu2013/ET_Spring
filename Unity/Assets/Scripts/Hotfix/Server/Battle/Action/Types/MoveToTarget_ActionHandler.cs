using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [Action(ActionType.ActionType_MoveToTarget)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    [FriendOfAttribute(typeof(ET.Server.Action))]
    [FriendOf(typeof(BulletComponent))]
    public class MoveToTarget_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Unit unit = null;
            List<long> targets = new();

            switch (type)
            {
                case ActionTriggerType.CastHit:
                    Cast cast = action.Cast;
                    unit = cast.Caster;
                    targets = cast.Targets;
                    break;

                case ActionTriggerType.BulletTick:
                    BulletComponent bulletComponent = action.BulletComponent;
                    unit = action.Caster;
                    targets = bulletComponent.Targets;
                    break;
            }
            
            float3 newPosition = float3.zero;
            ActionConfig config = action.Config;
            MoveToTargetParams moveToTargetParams = (MoveToTargetParams)config.ActionParams;
            if (moveToTargetParams == null)
            {
                return;
            }

            float speed = moveToTargetParams.Speed;

            Unit target = null;

            if (targets.Count > 0)
            {
                UnitComponent unitComponent = action.Scene().GetComponent<UnitComponent>();
                Unit temp = unitComponent.Get(targets[0]);
                if (temp != null && !temp.IsDisposed && temp != unit)
                {
                    target = temp;
                }
            }

            if (target != null)
            {
                newPosition = unit.Position + math.normalize(target.Position - unit.Position) * speed;
            }
            else
            {
                newPosition = unit.Position + math.normalize(unit.Forward) * speed;
            }

            newPosition.y = unit.Position.y;
            
            unit.FindPathMoveToAsync(newPosition).Coroutine();
            
            Log.Console($"Unit {unit.Id} 向目标移动{speed}米， newPosition：{newPosition}");
        }
    }
}