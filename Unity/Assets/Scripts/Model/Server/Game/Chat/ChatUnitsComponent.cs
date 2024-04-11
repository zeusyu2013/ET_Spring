using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class ChatUnitsComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, EntityRef<ChatUnit>> ChatUnitsDict = new();
    }
}
