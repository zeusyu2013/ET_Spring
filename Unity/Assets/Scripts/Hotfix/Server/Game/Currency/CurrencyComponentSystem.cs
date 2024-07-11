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

        public static long GetCurrencyValue(this CurrencyComponent self, CurrencyType type)
        {
            if (type is <= 0 or >= CurrencyType.CurrencyType_Max)
            {
                return 0;
            }

            return self.Currencies[(int)type];
        }

        public static bool Inc(this CurrencyComponent self, CurrencyType type, long value, string reason)
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

            long oldValue = self.Currencies[(int)type];

            self.Currencies[(int)type] = oldValue + value;

            // 发送变化
            EventSystem.Instance.Publish(self.Root(),
                new CurrencyChanged()
                {
                    Unit = self.GetParent<Unit>(),
                    ChangeType = CurrencyChangeType.Inc,
                    Type = type,
                    CurrencyChangeReason = reason,
                    OldValue = oldValue,
                    NewValue = self.Currencies[(int)type]
                });

            return true;
        }

        public static bool Dec(this CurrencyComponent self, CurrencyType type, long value, string reason)
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

            // 发送变化
            EventSystem.Instance.Publish(self.Root(),
                new CurrencyChanged()
                {
                    Unit = self.GetParent<Unit>(),
                    ChangeType = CurrencyChangeType.Dec,
                    Type = type,
                    CurrencyChangeReason = reason,
                    OldValue = current,
                    NewValue = current - value
                });

            return true;
        }
    }
}