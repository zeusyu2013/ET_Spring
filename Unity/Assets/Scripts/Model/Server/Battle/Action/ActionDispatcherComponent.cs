using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Code]
    public class ActionDispatcherComponent : Singleton<ActionDispatcherComponent>, ISingletonAwake
    {
        public Dictionary<ActionType, IAction> Actions = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(ActionAttribute));
            foreach (Type type in types)
            {
                var attrs = type.GetCustomAttributes(typeof(ActionAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                ActionAttribute actionAttribute = attrs[0] as ActionAttribute;

                object o = Activator.CreateInstance(type);

                if (o is not IAction iAction)
                {
                    return;
                }

                Actions[actionAttribute.ActionType] = iAction;
            }
        }

        public IAction Get(ActionType type)
        {
            if (this.Actions.TryGetValue(type, out IAction handler))
            {
                return handler;
            }

            return null;
        }
    }
}