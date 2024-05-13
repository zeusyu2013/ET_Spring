using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class EquipmentComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        // key为equipmenttype，枚举做key效率低下且不利于序列化
        public Dictionary<int, EntityRef<GameItem>> Equipments = new();
    }
}