using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [UnitCacheEvent(typeof(EquipmentComponent))]
    [ComponentOf(typeof(Unit))]
    public class EquipmentComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        // key为equipmenttype，枚举做key效率低下且不利于序列化
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, EntityRef<GameItem>> Equipments = new();
    }
}