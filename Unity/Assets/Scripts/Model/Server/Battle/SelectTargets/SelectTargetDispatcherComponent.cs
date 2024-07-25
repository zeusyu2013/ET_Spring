using System;
using System.Collections.Generic;

namespace ET
{
    [Code]
    public class SelectTargetDispatcherComponent : Singleton<SelectTargetDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<string, ASelectTargetHandler> selectTargetHandlers = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(SelectTargetAttribute));
            foreach (Type type in types)
            {
                ASelectTargetHandler astHandler = Activator.CreateInstance(type) as ASelectTargetHandler;
                if (astHandler == null)
                {
                    Log.Error($"robot ai is not ASelectTargetHandler: {type.Name}");
                    continue;
                }

                this.selectTargetHandlers.Add(type.Name, astHandler);
            }
        }

        public ASelectTargetHandler Get(string key)
        {
            this.selectTargetHandlers.TryGetValue(key, out var handler);
            return handler;
        }
    }
}