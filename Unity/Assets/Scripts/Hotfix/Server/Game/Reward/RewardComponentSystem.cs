namespace ET.Server
{
    [EntitySystemOf(typeof(RewardComponent))]
    public static partial class RewardComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RewardComponent self)
        {
        }

        public static void Reward(this RewardComponent self, int rewardId)
        {
            RewardConfig config = RewardConfigCategory.Instance.Get(rewardId);
            if (config == null)
            {
                Log.Error($"错误的奖励包id：{rewardId}");
                return;
            }

            foreach (var kv in config.Reward)
            {
                int itemId = kv.Key;
                long itemAmount = kv.Value;

                self.GetParent<Unit>().GetComponent<BagComponent>().AddItem(itemId, itemAmount);
            }
        }
    }
}