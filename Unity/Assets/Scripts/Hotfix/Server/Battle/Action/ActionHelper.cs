namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.Action))]
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    [FriendOfAttribute(typeof(ET.Server.Buff))]
    public static class ActionHelper
    {
        public static Action Create(this ActionTempComponent self, int configId)
        {
            return self.AddChild<Action, int>(configId);
        }

        public static Action Create(this Buff buff, int configId, ActionTriggerType type, bool autoAction = true, bool autoDestroy = true)
        {
            Action action = buff.GetComponent<ActionTempComponent>().Create(configId);
            action.Owner = buff.Owner;
            
            DoAction(action, type, autoAction, autoDestroy);

            return action;
        }

        public static Action Create(this Cast cast, int configId, Unit owner, ActionTriggerType type, bool autoAction = true, bool autoDestroy = true)
        {
            Action action = cast.GetComponent<ActionTempComponent>().Create(configId);
            action.Caster = cast.Caster;
            action.Owner = owner;

            DoAction(action, type, autoAction, autoDestroy);

            if (action.IsDisposed)
            {
                return null;
            }

            return action;
        }

        public static void DoAction(Action action, ActionTriggerType type, bool autoAction = true, bool autoDestroy = true)
        {
            if (!autoAction)
            {
                return;
            }

            if (autoDestroy)
            {
                using (action)
                {
                    DoActionInner(action, type);
                }
            }
            else
            {
                DoActionInner(action, type);
            }
        }

        private static void DoActionInner(Action action, ActionTriggerType type)
        {
            IAction actionHandler = ActionDispatcherComponent.Instance.Get(action.Config.Type);
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