using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(LotteryComponent))]
    [FriendOfAttribute(typeof(ET.Server.LotteryComponent))]
    public static partial class LotteryComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.LotteryComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.LotteryComponent self)
        {
        }

        public struct LotteryRange
        {
            public int Min;
            public int Max;
        }

        public static void Do(this LotteryComponent self)
        {
            LotteryConfig config = LotteryConfigCategory.Instance.Get(self.Level);
            if (config == null)
            {
                return;
            }

            int max = config.LotteryInfos.Values.Sum();
            if (max != 10000)
            {
                Log.Error($"宝箱概率不为10000，请检查配置 宝箱等级：{self.Level}");
                return;
            }

            Dictionary<LotteryRange, LotteryQuality> ranges = new();

            int index = 0;
            foreach ((LotteryQuality key, int value) in config.LotteryInfos)
            {
                ranges.Add(new LotteryRange() { Min = index, Max = index + value }, key);
            }

            LotteryQuality quality = LotteryQuality.LotteryQuality_Gray;
            int random = RandomGenerator.RandomNumber(0, 10000);
            foreach ((LotteryRange key, LotteryQuality value) in ranges)
            {
                if (key.Min < random && random < key.Max)
                {
                    quality = value;
                    break;
                }
            }

            if (quality == LotteryQuality.LotteryQuality_Red)
            {
                Log.Info($"随机出神话装备，随机值：{random}");
            }

            self.GenRandomEquipment(quality);
        }

        private static void GenRandomEquipment(this LotteryComponent self, LotteryQuality quality)
        {
        }

        public static int Upgrade(this LotteryComponent self)
        {
            LotteryConfig config = LotteryConfigCategory.Instance.Get(self.Level);
            if (config == null)
            {
                return ErrorCode.ERR_NotFoundLotteryConfig;
            }

            int buildingConfig = config.UpgradeBuildingConfig;
            int buildingLevel = config.UpgradeBuildingLevel;

            // 建筑等级不满足
            bool ret = self.GetParent<Unit>().GetComponent<BuildingComponent>().CheckConfigAndLevel(buildingConfig, buildingLevel);
            if (!ret)
            {
                return ErrorCode.ERR_BuildingLevelNotMatch;
            }

            ret = self.GetParent<Unit>().GetComponent<CurrencyComponent>().Dec(config.UpgradeCurrencyType, config.UpgradeCurrencyValue, "升级宝箱");
            if (!ret)
            {
                return ErrorCode.ERR_CurrencyNotEnough;
            }

            self.Level += 1;

            return ErrorCode.ERR_Success;
        }
    }
}