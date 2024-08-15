using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class ChatUnitsComponent : Entity, IAwake, IDestroy
    {
        // 存储的玩家映射 key -> unitId  value -> 玩家映射数据
        public Dictionary<long, EntityRef<ChatUnit>> ChatUnitsDict = new();
    }
}
