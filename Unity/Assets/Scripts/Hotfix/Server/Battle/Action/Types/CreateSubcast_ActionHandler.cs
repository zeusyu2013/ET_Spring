namespace ET.Server
{
    [Action(ActionType.ActionType_CastSubcast)]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public class CreateSubcast_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            RunAsync(action, type).Coroutine();
        }

        public async ETTask RunAsync(Action action, ActionTriggerType type)
        {
            Cast cast = action.Cast;
            if (cast == null || cast.IsDisposed || type != ActionTriggerType.CastFinish)
            {
                return;
            }

            ActionConfig config = action.Config;
            SubcastParams subcastParams = (SubcastParams)config.ActionParams;
            if (subcastParams == null)
            {
                return;
            }

            Unit caster = cast.Caster;

            await action.Scene().GetComponent<TimerComponent>().WaitFrameAsync();

            if (caster.IsDisposed)
            {
                return;
            }

            caster.CreateAndCast(subcastParams.SubCastConfigId);
        }
    }
}