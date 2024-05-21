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
            int nowDays = TimeInfo.Instance.TotalDays();
            if (nowDays == self.SigninDay)
            {
                return ErrorCode.ERR_SigninedToday;
            }

            // 发放签到奖励
            self.GetParent<Unit>().GetComponent<RewardComponent>().Reward(1);

            self.SigninDay = nowDays;

            return ErrorCode.ERR_Success;
        }
    }
}