﻿namespace ET.Server
{
    [EntitySystemOf(typeof(OfflineIncomeComponent))]
    [FriendOfAttribute(typeof(OfflineIncomeComponent))]
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

            // 统计diff秒收益
            // TODO:这里随便设置下，1s 100金币 10经验值
            long gold = diff * 100;
            long exp = diff * 10;
            self.GetParent<Unit>().GetComponent<CurrencyComponent>().Inc(CurrencyType.CurrencyType_Gold, gold);
            self.GetParent<Unit>().GetComponent<PlayerLevelComponent>().AddExp(exp);

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