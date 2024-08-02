using Unity.Mathematics;

namespace ET.Server
{
    [Action(ActionType.ActionType_CastBullet)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class CastBullet_ActionHandler : IAction
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

            if (cast.Targets.Count < 1)
            {
                return;
            }

            ActionConfig config = action.Config;

            float3 bulletPosition = caster.Position + (caster.Forward * 1.2f);
            
            UnitComponent unitComponent = action.Scene().GetComponent<UnitComponent>();
            foreach (long id in cast.Targets)
            {
                Unit target = unitComponent.Get(id);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                Unit bullet = UnitFactory.CreateBullet(cast.Scene(), caster.Id, config.Id, config.Id, bulletPosition, caster.Rotation);
                bullet.GetComponent<BulletComponent>().Start();
            }
        }
    }
}