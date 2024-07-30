using System;
using System.Collections.Generic;

namespace ET
{
    [Code]
    public class SelectTargetDispatcherComponent : Singleton<SelectTargetDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<SelectTargetType, ASelectTargetHandler> selectTargetHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SelectTargetAttribute));
            foreach (Type type in types)
            {
                object[] atts = type.GetCustomAttributes(typeof(SelectTargetAttribute), false);
                if (atts.Length == 0)
                {
                    continue;
                }

                SelectTargetAttribute attribute = atts[0] as SelectTargetAttribute;
                if (attribute == null)
                {
                    continue;
                }

                SelectTargetType selectTargetType = attribute.Type;
                ASelectTargetHandler astHandler = Activator.CreateInstance(type) as ASelectTargetHandler;
                if (astHandler == null)
                {
                    Log.Error($"robot ai is not ASelectTargetHandler: {type.Name}");
                    continue;
                }

                this.selectTargetHandlers.Add(selectTargetType, astHandler);
            }
        }

        public ASelectTargetHandler Get(SelectTargetType type)
        {
            this.selectTargetHandlers.TryGetValue(type, out var handler);
            return handler;
        }
    }
}