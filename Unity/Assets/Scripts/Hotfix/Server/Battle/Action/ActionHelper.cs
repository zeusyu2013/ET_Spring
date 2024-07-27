namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.Skill))]
    [FriendOfAttribute(typeof(ET.Server.Action))]
    public static class ActionHelper
    {
        public static Action Create(this ActionTempComponent self, int configId)
        {
            return self.AddChild<Action, int>(configId);
        }

        public static Action Create(this Skill skill, int configId, Unit owner, ActionType type, bool autoAction = true, bool autoDestroy = true)
        {
            Action action = skill.GetComponent<ActionTempComponent>().Create(configId);
            action.Caster = skill.Caster;
            action.Owner = owner;

            DoAction(action, type, autoAction, autoDestroy);

            if (action.IsDisposed)
            {
                return null;
            }

            return action;
        }

        public static void DoAction(Action action, ActionType type, bool autoAction = true, bool autoDestroy = true)
        {
            if (!autoAction)
            {
                return;
            }

            if (autoDestroy)
            {
                using (action)
                {
                    DoAction(action, type);
                }
            }
            else
            {
                DoAction(action, type);
            }
        }

        private static void DoAction(Action action, ActionType type)
        {
            IAction actionHandler = ActionDispatcherComponent.Instance.Get(action.Config.Type);
            if (actionHandler == null)
            {
                Log.Error($"没找到对应{action.Config.Type}的行为");
                action.Dispose();
                return;
            }

            actionHandler.Run(action, type);
        }
    }
}