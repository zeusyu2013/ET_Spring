namespace ET.Server
{
    [Action(ActionType.ActionType_Treatment)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class Treatment_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Cast cast = action.Cast;
            if (cast == null)
            {
                return;
            }

            if (type != ActionTriggerType.CastHit && type != ActionTriggerType.BuffTick)
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
                
                BattleHelper.CalcTreatment(cast.Caster, target, action);
            }
        }
    }
}