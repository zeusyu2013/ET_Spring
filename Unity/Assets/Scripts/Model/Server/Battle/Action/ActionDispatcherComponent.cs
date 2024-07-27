using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class ActionDispatcherComponent : Entity, IAwake, IDestroy
    {
        [StaticField]
        public static ActionDispatcherComponent Instance;

        public Dictionary<int, IAction> Actions = new();
    }
}