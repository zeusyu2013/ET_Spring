namespace ET
{
    [EntitySystemOf(typeof(CurrencyComponent))]
    [FriendOfAttribute(typeof(ET.CurrencyComponent))]
    public static partial class CurrencyComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.CurrencyComponent self)
        {
        }

        public static bool Inc(this CurrencyComponent self, CurrencyType type, long value)
        {
            if (type is <= 0 or >= CurrencyType.CurrencyType_Max)
            {
                return false;
            }

            if (value < 0)
            {
                return false;
            }

            // 没有此类型，尝试添加
            self.Currencies.TryAdd(type, 0);

            self.Currencies[type] += value;

            return true;
        }

        public static bool Dec(this CurrencyComponent self, CurrencyType type, long value)
        {
            if (value < 0)
            {
                return false;
            }

            if (!self.Currencies.ContainsKey(type))
            {
                return false;
            }

            long current = self.Currencies[type];
            if (current < value)
            {
                return false;
            }

            self.Currencies[type] = current - value;

            return true;
        }

        [EntitySystem]
        private static void Deserialize(this ET.CurrencyComponent self)
        {
        }
    }
}