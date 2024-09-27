using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Code]
    public class SoulActionDispatcherComponent : Singleton<SoulActionDispatcherComponent>, ISingletonAwake
    {
        private Dictionary<SoulActionType, ISoulAction> Actions = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SoulActionAttribute));
            foreach (Type type in types)
            {
                var attrs = type.GetCustomAttributes(typeof(SoulActionAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                SoulActionAttribute actionAttribute = attrs[0] as SoulActionAttribute;

                object o = Activator.CreateInstance(type);

                if (o is not ISoulAction iAction)
                {
                    return;
                }

                Actions[actionAttribute.ActionType] = iAction;
            }
        }

        public ISoulAction Get(SoulActionType type)
        {
            return this.Actions.GetValueOrDefault(type);
        }
    }
}