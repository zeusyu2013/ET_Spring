using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(ActionDispatcherComponent))]
    [FriendOfAttribute(typeof(ET.Server.ActionDispatcherComponent))]
    public static partial class ActionDispatcherComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ActionDispatcherComponent self)
        {
            ActionDispatcherComponent.Instance = self;

            self.Load();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.ActionDispatcherComponent self)
        {
            ActionDispatcherComponent.Instance = null;
            self.Actions.Clear();
        }

        private static void Load(this ActionDispatcherComponent self)
        {
            self.Actions.Clear();

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

                IAction iAction = o as IAction;
                if (iAction == null)
                {
                    throw new Exception($"class {type.Name} not inherit from IAction");
                }

                self.Actions[actionAttribute.ActionType] = iAction;
            }
        }

        public static IAction Get(this ActionDispatcherComponent self, ActionType type)
        {
            return self.Actions.GetValueOrDefault(type);
        }
    }
}