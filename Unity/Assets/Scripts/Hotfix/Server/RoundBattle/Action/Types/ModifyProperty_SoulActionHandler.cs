namespace ET.Server
{
    [SoulAction(SoulActionType.SoulActionType_ModifyProperty)]
    [FriendOfAttribute(typeof(ET.Server.SoulAction))]
    public class ModifyProperty_SoulActionHandler : ISoulAction
    {
        public void Run(SoulAction soulAction, SoulActionTriggerType type)
        {
            Soul owner = soulAction.Owner;
            if (owner == null || owner.IsDisposed)
            {
                return;
            }

            ModifyPropertyActionParams modifyPropertyActionParams = (ModifyPropertyActionParams)soulAction.Config.ActionParams;
            if (modifyPropertyActionParams == null)
            {
                return;
            }

            switch (type)
            {
                case SoulActionTriggerType.CastHit:
                case SoulActionTriggerType.BuffAdd:
                {
                    NumericComponent numericComponent = owner.GetComponent<NumericComponent>();
                    foreach (Properties properties in modifyPropertyActionParams.ModifyProperties)
                    {
                        numericComponent.IncLong(properties.Property, properties.Value);
                    }
                }
                    break;

                case SoulActionTriggerType.BuffRemove:
                {
                    NumericComponent numericComponent = owner.GetComponent<NumericComponent>();
                    foreach (Properties properties in modifyPropertyActionParams.ModifyProperties)
                    {
                        numericComponent.DecLong(properties.Property, properties.Value);
                    }
                }
                    break;

                default:
                    break;
            }
        }
    }
}