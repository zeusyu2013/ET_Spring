using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(ShopComponent))]
    [FriendOfAttribute(typeof(ET.Server.ShopComponent))]
    public static partial class ShopComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ShopComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.ShopComponent self)
        {
        }

        public static void BuyItem(this ShopComponent self, int itemConfig, long itemAmount)
        {
            ShopConfig config = ShopConfigCategory.Instance.Get(itemConfig);
            if (config == null)
            {
                return;
            }

            if (itemAmount > config.Limit)
            {
                return;
            }

            if (self.ShopBuyCounts.TryGetValue(itemConfig, out long value))
            {
                if (itemAmount > config.Limit - value)
                {
                    return;
                }
            }

            bool ret = self.GetParent<Unit>().GetComponent<CurrencyComponent>().Dec(config.CurrencyType, config.CurrencyValue, "商店购买");
            if (!ret)
            {
                return;
            }

            self.GetParent<Unit>().GetComponent<BagComponent>().AddItem(itemConfig, itemAmount);

            if (!self.ShopBuyCounts.ContainsKey(itemConfig))
            {
                self.ShopBuyCounts.Add(itemConfig, 0);
            }

            self.ShopBuyCounts[itemConfig] += itemAmount;
        }

        public static void NewDay(this ShopComponent self)
        {
            self.ShopBuyCounts.Clear();
        }

        public static List<ShopItemInfo> ToMessage(this ShopComponent self)
        {
            List<ShopItemInfo> infos = new();
            foreach ((int key, long value) in self.ShopBuyCounts)
            {
                ShopItemInfo info = ShopItemInfo.Create();
                info.ItemConfig = key;
                info.ItemAmount = value;
                infos.Add(info);
            }

            return infos;
        }
    }
}