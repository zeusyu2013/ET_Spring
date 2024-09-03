using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ComponentOf(typeof(Soul))]
    public class SoulTalentComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, int> SoulTalents = new();
    }
}