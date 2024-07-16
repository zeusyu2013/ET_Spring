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
            if (!int.TryParse(productConfigId, out int id))
            {
                return;
            }

            ChargeConfig config = ChargeConfigCategory.Instance.Get(id);
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
            
            self.PayAmount += config.Price;
        }
    }
}