using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class ShopComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, long> ShopBuyCounts = new();
    }
}