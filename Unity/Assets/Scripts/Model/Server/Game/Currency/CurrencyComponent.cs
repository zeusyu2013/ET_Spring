using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class CurrencyComponent : Entity, IAwake, IDeserialize
    {
        public Dictionary<CurrencyType, long> Currencies = new();
    }
}