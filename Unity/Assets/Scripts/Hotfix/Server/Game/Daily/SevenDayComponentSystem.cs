namespace ET.Server
{
    [EntitySystemOf(typeof(SevenDayComponent))]
    [FriendOfAttribute(typeof(ET.Server.SevenDayComponent))]
    public static partial class SevenDayComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SevenDayComponent self)
        {
            self.BeginDay = TimeInfo.Instance.TotalDays();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SevenDayComponent self)
        {
            
        }

        public static void Get(this SevenDayComponent self)
        {
            int today = TimeInfo.Instance.TotalDays();
            if (today == self.GetDay)
            {
                return;
            }

            if (self.GetCount >= 7)
            {
                return;
            }

            SevenDayConfig config = SevenDayConfigCategory.Instance.Get(self.GetCount);

            self.GetParent<Unit>().GetComponent<RewardComponent>().Reward(config.Reward);

            self.GetDay = today;
            self.GetCount += 1;
        }
    }
}