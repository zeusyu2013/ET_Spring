namespace ET.Server
{
    [Action(ActionType.ActionType_Relive)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class Relive_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Cast cast = action.Cast;
            if (cast == null || type != ActionTriggerType.CastFinish)
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

                if (target.IsAlive())
                {
                    continue;
                }

                BattleHelper.Relive(cast.Caster, target, action);
            }
        }
    }
}