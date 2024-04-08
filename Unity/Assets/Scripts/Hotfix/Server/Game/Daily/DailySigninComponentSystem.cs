namespace ET.Server
{
    [EntitySystemOf(typeof(DailySigninComponent))]
    [FriendOfAttribute(typeof(ET.Server.DailySigninComponent))]
    public static partial class DailySigninComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DailySigninComponent self)
        {
        }

        public static void Signin(this DailySigninComponent self)
        {
            int nowDays = TimeInfo.Instance.TotalDays();
            if (nowDays == self.SigninDay)
            {
                return;
            }

            // 发放签到奖励
            self.Root().GetComponent<RewardComponent>().Reward(1);

            self.SigninDay = nowDays;
        }
    }
}