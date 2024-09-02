using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ComponentOf(typeof(SoulRune))]
    public class SoulRuneRandomPropertiesComponent : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> RandomProperties = new();
    }
}