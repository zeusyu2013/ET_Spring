using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class CurrencyComponent : Entity, IAwake, ISerializeToEntity
    {
        public Dictionary<CurrencyType, long> Currencies = new();
    }
}