using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [UnitCacheEvent(typeof(EquipmentContainerComponent))]
    [ComponentOf(typeof(Unit))]
    public class EquipmentContainerComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        // key为equipmenttype，枚举做key效率低下且不利于序列化
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, EntityRef<GameItem>> Equipments = new();
    }
}