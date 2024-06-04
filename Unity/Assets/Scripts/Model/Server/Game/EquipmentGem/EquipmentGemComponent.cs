using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ComponentOf]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class EquipmentGemComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        // 索引是宝石孔的位置索引
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, int> Gems = new();

        [BsonIgnore]
        public EquipmentHoleConfig Config => EquipmentHoleConfigCategory.Instance.Get(this.GetParent<GameItem>().ConfigId);
    }
}