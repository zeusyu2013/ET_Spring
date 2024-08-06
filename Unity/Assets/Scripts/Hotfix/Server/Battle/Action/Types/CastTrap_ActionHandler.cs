using Unity.Mathematics;

namespace ET.Server
{
    [Action(ActionType.ActionType_CastTrap)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class CastTrap_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Cast cast = action.Cast;
            if (cast == null || type != ActionTriggerType.CastHit)
            {
                return;
            }

            Unit caster = cast.Caster;
            if (caster == null || caster.IsDisposed)
            {
                return;
            }

            ActionConfig config = action.Config;

            // todo 位置朝向由客户端上报
            Unit trap = UnitFactory.CreateTrap(action.Scene(), caster.Id, config.Id, config.Id, float3.zero, quaternion.identity);
            trap.GetComponent<TrapComponent>().Start();
        }
    }
}