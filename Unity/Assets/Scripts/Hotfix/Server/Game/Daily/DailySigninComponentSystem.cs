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
        
        [EntitySystem]
        private static void Destroy(this ET.Server.DailySigninComponent self)
        {
            self.SigninDay = 0;
        }

        public static int Signin(this DailySigninComponent self)
        {
            int nowDay = TimeInfo.Instance.DayOfMonth();
            if (nowDay == self.SigninDay)
            {
                return ErrorCode.ERR_SigninedToday;
            }

            SignConfig config = SignConfigCategory.Instance.Get(nowDay);
            if (config == null)
            {
                return ErrorCode.ERR_DailySignErrorDay;
            }

            // 发放签到奖励
            self.GetParent<Unit>().GetComponent<RewardComponent>().Reward(config.SignReward);

            self.SigninDay = nowDay;

            return ErrorCode.ERR_Success;
        }
    }
}