namespace ET.Server
{
    [EntitySystemOf(typeof(PlayerLevelComponent))]
    [FriendOf(typeof(PlayerLevelComponent))]
    public static partial class PlayerLevelComponentSystem
    {
        private static void Awake(this PlayerLevelComponent self, int level)
        {
            self.Level = level;
        }

        private static void Destroy(this PlayerLevelComponent self)
        {
        }

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
            self.GetParent<Unit>().GetComponent<NumericComponent>().Set(GamePropertyType.GamePropertyType_Level, self.Level);
            self.GetParent<Unit>().GetComponent<NumericComponent>().SetNoEvent(GamePropertyType.GamePropertyType_Exp, self.Exp);
            self.GetParent<Unit>().GetComponent<NumericComponent>().SetNoEvent(GamePropertyType.GamePropertyType_MaxExp, self.MaxExp);
        }
    }
}