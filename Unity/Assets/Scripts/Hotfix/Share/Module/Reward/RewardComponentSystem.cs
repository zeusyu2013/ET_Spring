namespace ET
{
    [EntitySystemOf(typeof(RewardComponent))]
    public static partial class RewardComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.RewardComponent self)
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
                int itemCount = kv.Value;
            }
        }
    }
}