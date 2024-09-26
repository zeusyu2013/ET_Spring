namespace ET.Server
{
    [EntitySystemOf(typeof(AvocationComponent))]
    [FriendOfAttribute(typeof(AvocationComponent))]
    [FriendOfAttribute(typeof(Avocation))]
    public static partial class AvocationComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AvocationComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this AvocationComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                Avocation avocation = entity as Avocation;

                self.Avocations.Add(avocation.AvocationType, avocation);
            }
        }

        public static void LearnAvocation(this AvocationComponent self, AvocationType type)
        {
            if (self.Avocations.ContainsKey(type))
            {
                return;
            }

            Avocation avocation = self.AddChild<Avocation, AvocationType>(type);

            self.Avocations.Add(type, avocation);
        }

        public static void AddExp(this AvocationComponent self, AvocationType type, long exp)
        {
            if (!self.Avocations.ContainsKey(type))
            {
                return;
            }

            Avocation avocation = self.Avocations[type];
            if (avocation.Level >= avocation.Config.UpgradeExp.Count)
            {
                return;
            }

            long max = avocation.Config.UpgradeExp[avocation.Level];
            if (avocation.Exp >= max)
            {
                return;
            }
            
            avocation.Exp += exp;
            if (avocation.Exp > max)
            {
                avocation.Exp = max;
            }
        }

        public static void UpgradeAvocation(this AvocationComponent self, AvocationType type)
        {
            if (!self.Avocations.ContainsKey(type))
            {
                return;
            }

            Avocation avocation = self.Avocations[type];

            // 满级不处理
            if (avocation.Level >= avocation.Config.UpgradeConsume.Count)
            {
                return;
            }

            // 经验值没满 不处理
            if (avocation.Exp < avocation.Config.UpgradeExp[avocation.Level])
            {
                return;
            }

            long consume = avocation.Config.UpgradeConsume[avocation.Level];

            // 钱不够，不处理
            int ret = self.GetParent<Unit>().GetComponent<CurrencyComponent>().Dec(CurrencyType.CurrencyType_Gold, consume, "升级生活技能");
            if (ret != ErrorCode.ERR_Success)
            {
                return;
            }

            avocation.Exp = 0;
            avocation.Level += 1;
        }
    }
}