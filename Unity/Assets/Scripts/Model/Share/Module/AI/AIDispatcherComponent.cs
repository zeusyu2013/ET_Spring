using System;
using System.Collections.Generic;

namespace ET
{
    [Code]
    public class AIDispatcherComponent: Singleton<AIDispatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<AIType, AAIHandler> aiHandlers = new();
        
        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof (AIHandlerAttribute));
            foreach (Type type in types)
            {
                object[] atts = type.GetCustomAttributes(typeof(AIHandlerAttribute), false);
                if (atts.Length == 0)
                {
                    continue;
                }

                AIHandlerAttribute attribute = atts[0] as AIHandlerAttribute;
                if (attribute == null)
                {
                    continue;
                }

                AIType aiType = attribute.AIType;
                
                AAIHandler aaiHandler = Activator.CreateInstance(type) as AAIHandler;
                if (aaiHandler == null)
                {
                    Log.Error($"robot ai is not AAIHandler: {type.Name}");
                    continue;
                }
                
                this.aiHandlers.Add(aiType, aaiHandler);
            }
        }

        public AAIHandler Get(AIType type)
        {
            this.aiHandlers.TryGetValue(type, out var aaiHandler);
            return aaiHandler;
        }
    }
}