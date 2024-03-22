using System.Collections.Generic;

namespace ET.Server
{
    public class EquipmentComponent : Entity, IAwake, IDeserialize, ISerializeToEntity, ITransfer
    {
        public long PlayerId;

        public Dictionary<int, EntityRef<GameItem>> Equipments = new();
    }
}