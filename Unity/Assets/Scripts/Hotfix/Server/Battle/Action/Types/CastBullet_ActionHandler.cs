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

            if (cast.Targets.Count < 1)
            {
                return;
            }

            ActionConfig config = action.Config;
            
            UnitComponent unitComponent = action.Scene().GetComponent<UnitComponent>();
            foreach (long id in cast.Targets)
            {
                Unit target = unitComponent.Get(id);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                Unit caster = cast.Caster;
                Unit bullet = UnitFactory.CreateBullet(cast.Scene(), caster.Id, config.Id, config.Id, target.Position);
                bullet.GetComponent<BulletComponent>().Start();
            }
        }
    }
}