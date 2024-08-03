using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class ClientTaskComponent : Entity, IAwake, IDestroy
    {
        public List<int> AcceptedTasks = new();
    }
}