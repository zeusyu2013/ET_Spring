namespace ET.Server
{
    [EntitySystemOf(typeof(OfflineIncomeComponent))]
    [FriendOfAttribute(typeof(OfflineIncomeComponent))]
    [FriendOfAttribute(typeof(ET.Server.VipComponent))]
    [FriendOfAttribute(typeof(ET.Server.LevelComponent))]
    public static partial class OfflineIncomeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OfflineIncomeComponent self)
        {
            if (self.LastIncomeTime == 0)
            {
                self.LastIncomeTime = TimeInfo.Instance.ServerNow();
            }
        }

        public static OfflineIncomeInfo GetOfflineIncome(this OfflineIncomeComponent self)
        {
            OfflineIncomeInfo info = OfflineIncomeInfo.Create();

            long now = TimeInfo.Instance.ServerNow();
            if (self.LastIncomeTime > now)
            {
                self.LastIncomeTime = now;
                return info;
            }

            long diff = (now - self.LastIncomeTime) / 1000;
            if (diff < 1)
            {
                return info;
            }

            Unit unit = self.GetParent<Unit>();

            VipConfig vipConfig = VipConfigCategory.Instance.Get(unit.GetComponent<VipComponent>().VipLevel);

            OfflineIncomeConfig offlineIncomeConfig = OfflineIncomeConfigCategory.Instance.Get(unit.GetComponent<LevelComponent>().Level);
            if (diff >= offlineIncomeConfig.MaxTime + vipConfig.OfflineAddTime)
            {
                diff = offlineIncomeConfig.MaxTime + vipConfig.OfflineAddTime;
            }

            float rate = 1 + vipConfig.OfflineRate / 10000f;

            // 统计diff秒收益
            long gold = (long)(diff * offlineIncomeConfig.Gold * rate);
            long exp = (long)(diff * offlineIncomeConfig.Exp * rate);
            
            self.GetParent<Unit>().GetComponent<CurrencyComponent>().Inc(CurrencyType.CurrencyType_Gold, gold, "离线收益");
            self.GetParent<Unit>().GetComponent<LevelComponent>().AddExp(exp);

            info.Time = diff;
            info.Gold = gold;
            info.Exp = exp;

            // 设置最后一次领取时间
            self.LastIncomeTime = now;

            return info;
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.OfflineIncomeComponent self)
        {
        }
    }
}