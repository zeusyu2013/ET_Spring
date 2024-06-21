namespace ET.Server
{
    [EntitySystemOf(typeof(FightScoreComponent))]
    [FriendOfAttribute(typeof(ET.NumericComponent))]
    [FriendOfAttribute(typeof(ET.Server.FightScoreComponent))]
    public static partial class FightScoreComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.FightScoreComponent self)
        {
        }

        public static void RefreshFightScore(this FightScoreComponent self)
        {
            NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                return;
            }

            long score = 0;
            foreach ((int key, long value) in numericComponent.NumericDic)
            {
                var config = PropertyScoreConfigCategory.Instance.Get((GamePropertyType)key);
                if (config == null)
                {
                    continue;
                }

                score += config.Score * value;
            }

            if (score <= self.FightScore)
            {
                return;
            }

            EventSystem.Instance.Publish(self.Root(),
                new FightScoreChanged() { Unit = self.GetParent<Unit>(), OldFightScore = self.FightScore, NewFightScore = score });

            self.FightScore = score;
        }
    }
}