using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    [ComponentOf(typeof(GameItem))]
    public class EquipmentInfoComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        /// <summary>
        /// key为属性枚举类型，即GamePropertyType
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> EquipmentBaseProperties = new();
        
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> EquipmentRandomProperties = new();
    }
}