namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.SoulAction))]
    [FriendOfAttribute(typeof(ET.Server.SoulCast))]
    [FriendOfAttribute(typeof(ET.Server.SoulBuff))]
    public static class SoulActionHelper
    {
        public static SoulAction Create(this SoulCast self, int configId, Soul owner, SoulActionTriggerType type, bool autoAction = true, bool autoDestroy = true)
        {
            SoulAction action = self.GetComponent<SoulActionComponent>().Create(configId);
            action.Caster = self.Caster;
            action.Owner = owner;

            DoAction(action, type, autoAction, autoDestroy);

            if (action.IsDisposed)
            {
                return null;
            }

            return action;
        }

        public static SoulAction Create(this SoulBuff self, int configId, SoulActionTriggerType type, bool autoAction = true, bool autoDestroy = true)
        {
            SoulAction action = self.GetComponent<SoulActionComponent>().Create(configId);
            action.Owner = self.Owner;
            
            DoAction(action, type, autoAction, autoDestroy);
            
            return action;
        }

        private static SoulAction Create(this SoulActionComponent self, int configId)
        {
            return self.AddChild<SoulAction, int>(configId);
        }

        private static void DoAction(SoulAction action, SoulActionTriggerType type, bool autoAction = true, bool autoDestroy = true)
        {
            if (!autoAction)
            {
                return;
            }

            if (autoDestroy)
            {
                using (action)
                {
                    DoSoulActionInner(action, type);
                }
            }
            else
            {
                DoSoulActionInner(action, type);
            }
        }

        private static void DoSoulActionInner(SoulAction action, SoulActionTriggerType type)
        {
            ISoulAction actionHandler = SoulActionDispatcherComponent.Instance.Get(action.Config.Type);
            if (actionHandler == null)
            {
                Log.Error($"没找到{action.ConfigId}对应{action.Config.Type}的行为");
                action.Dispose();
                return;
            }

            actionHandler.Run(action, type);
        }
    }
}