namespace ET.Server
{
    [Action(ActionType.ActionType_Disperse)]
    [FriendOfAttribute(typeof(ET.Server.Action))]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class Disperse_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Cast cast = action.Cast;
            Unit caster = action.Caster;
            if (caster == null || caster.IsDisposed || cast == null)
            {
                return;
            }

            if (type != ActionTriggerType.CastHit && type != ActionTriggerType.BuffTick)
            {
                return;
            }

            DisperseParams disperseParams = (DisperseParams)action.Config.ActionParams;
            if (cast.Targets.Count < 1)
            {
                if (disperseParams.IncludeSelf)
                {
                    cast.Targets.Add(caster.Id);
                }
                else
                {
                    Log.Error($"驱散目标为空");
                    return;
                }
            }

            UnitComponent unitComponent = action.Root().GetComponent<UnitComponent>();
            foreach (long id in cast.Targets)
            {
                Unit target = unitComponent.Get(id);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }

                BattleHelper.Disperse(caster, target, action);
            }
        }
    }
}