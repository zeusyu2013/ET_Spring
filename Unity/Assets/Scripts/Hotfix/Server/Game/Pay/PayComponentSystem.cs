namespace ET.Server
{
    [EntitySystemOf(typeof(PayComponent))]
    [FriendOfAttribute(typeof(ET.Server.PayComponent))]
    public static partial class PayComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PayComponent self)
        {

        }

        public static void Pay(this PayComponent self, string productConfigId)
        {
            ChargeConfig config = ChargeConfigCategory.Instance.Get(productConfigId);
            if (config == null)
            {
                return;
            }

            EventSystem.Instance.Publish(self.Root(),
                new PayAmountChanged()
                {
                    Unit = self.GetParent<Unit>(),
                    OldAmount = self.PayAmount,
                    NewAmount = self.PayAmount + config.Price
                });
            
            // 累加充值金额
            self.PayAmount += config.Price;
            
            // 立即保存组件信息，确保充值数据安全
            DBCacheHelper.SaveImmediately(self.Scene(), self);

            // 发放礼包
            self.GetParent<Unit>().GetComponent<BagComponent>().AddItem(config.Pack, 1);
        }
    }
}