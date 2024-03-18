namespace ET.Server
{
    [EntitySystemOf(typeof(PlayerLevelComponent))]
    [FriendOf(typeof(PlayerLevelComponent))]
    public static partial class PlayerLevelComponentSystem
    {
        public static void AddExp(this PlayerLevelComponent self, long exp)
        {
            long current = self.Exp + exp;
            long max = ExpConfigCategory.Instance.Get(self.Level).Exp;
            if (max < 1)
            {
                self.Exp += exp;
                return;
            }

            while (current >= max)
            {
                current -= max;

                self.Level += 1;

                max = ExpConfigCategory.Instance.Get(self.Level).Exp;
                if (max < 1)
                {
                    break;
                }
            }

            self.Exp = current;

            self.Boardcast();
        }

        public static void Boardcast(this PlayerLevelComponent self)
        {
            self.GetParent<Unit>().GetComponent<NumericComponent>().Set(PropertyType.PropertyType_Level, self.Level);
            self.GetParent<Unit>().GetComponent<NumericComponent>().SetNoEvent(PropertyType.PropertyType_Exp, self.Exp);
            self.GetParent<Unit>().GetComponent<NumericComponent>().SetNoEvent(PropertyType.PropertyType_MaxExp, self.MaxExp);
        }
    }
}