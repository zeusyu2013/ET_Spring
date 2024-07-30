namespace ET.Server
{
    [Action(ActionType.ActionType_ModifyProperty)]
    [FriendOfAttribute(typeof(ET.Server.Action))]
    public class ModifyProperty_ActionHandler : IAction
    {
        public void Run(Action action, ActionTriggerType type)
        {
            Unit owner = action.Owner;
            if (owner == null)
            {
                return;
            }

            ModifyPropertyActionParams actionParams = (ModifyPropertyActionParams)action.Config.ActionParams;
            if (actionParams == null)
            {
                return;
            }

            switch (type)
            {
                case ActionTriggerType.BuffAdd:
                case ActionTriggerType.CastHit:
                {
                    foreach (Properties properties in actionParams.ModifyProperties)
                    {
                        owner.IncLong(properties.Property, properties.Value);
                    }
                }
                    break;

                case ActionTriggerType.BuffRemove:
                {
                    foreach (Properties properties in actionParams.ModifyProperties)
                    {
                        owner.DecLong(properties.Property, properties.Value);
                    }
                }
                    break;
            }
        }
    }
}