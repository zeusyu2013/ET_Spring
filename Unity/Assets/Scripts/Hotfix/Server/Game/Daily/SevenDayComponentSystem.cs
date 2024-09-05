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

            int day = self.GetDay - self.BeginDay;
            if (day >= 7)
            {
                return;
            }

            SevenDayConfig config = SevenDayConfigCategory.Instance.Get(day);

            self.GetParent<Unit>().GetComponent<RewardComponent>().Reward(config.Reward);

            self.GetDay = today;
        }
    }
}