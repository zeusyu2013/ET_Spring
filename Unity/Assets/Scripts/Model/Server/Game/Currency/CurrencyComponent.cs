using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [UnitCacheEvent(typeof(CurrencyComponent))]
    [ComponentOf(typeof(Unit))]
    public class CurrencyComponent : Entity, IAwake, ITransfer, IUnitCache
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> Currencies = new();
    }
}