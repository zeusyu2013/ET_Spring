namespace ET.Server
{
    [Action(ActionType.ActionType_Damage)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class Damage_ActionHandler : IAction
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

            UnitComponent unitComponent = action.Root().GetComponent<UnitComponent>();
            
            foreach (long id in cast.Targets)
            {
                Unit target = unitComponent.Get(id);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }
                
                BattleHelper.CalcDamage(cast.Caster, target, action);
            }
        }
    }
}