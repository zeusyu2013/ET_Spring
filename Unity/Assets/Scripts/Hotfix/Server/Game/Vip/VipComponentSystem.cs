namespace ET.Server
{
    [EntitySystemOf(typeof(VipComponent))]
    [FriendOfAttribute(typeof(ET.Server.VipComponent))]
    public static partial class VipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.VipComponent self)
        {
        }

        public static void AddVipExp(this VipComponent self, long exp)
        {
            long current = self.VipExp + exp;
            long max = VipConfigCategory.Instance.Get(self.VipLevel).Exp;
            if (max < 1)
            {
                self.VipExp += exp;
                return;
            }

            while (current >= max)
            {
                current -= max;

                EventSystem.Instance.Publish(self.Root(),
                    new VipLevelChanged()
                    {
                        Unit = self.GetParent<Unit>(),
                        OldVipLevel = self.VipLevel,
                        NewVipLevel = self.VipLevel + 1
                    });

                self.VipLevel += 1;

                max = VipConfigCategory.Instance.Get(self.VipLevel).Exp;
                if (max < 1)
                {
                    break;
                }
            }

            self.VipExp = current;
        }
    }
}