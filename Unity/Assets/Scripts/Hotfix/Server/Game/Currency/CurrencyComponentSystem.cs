namespace ET.Server
{
    [EntitySystemOf(typeof(CurrencyComponent))]
    [FriendOfAttribute(typeof(CurrencyComponent))]
    public static partial class CurrencyComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CurrencyComponent self)
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
            self.Currencies.TryAdd((int)type, 0);

            self.Currencies[(int)type] += value;

            return true;
        }

        public static bool Dec(this CurrencyComponent self, CurrencyType type, long value)
        {
            if (value < 0)
            {
                return false;
            }

            if (!self.Currencies.ContainsKey((int)type))
            {
                return false;
            }

            long current = self.Currencies[(int)type];
            if (current < value)
            {
                return false;
            }

            self.Currencies[(int)type] = current - value;

            return true;
        }
    }
}