namespace ET
{
    [EntitySystemOf(typeof(PlayerLevelComponent))]
    [FriendOfAttribute(typeof(ET.PlayerLevelComponent))]
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
        }
    }
}