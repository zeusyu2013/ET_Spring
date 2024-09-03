namespace ET.Server
{
    [EntitySystemOf(typeof(Soul))]
    [FriendOfAttribute(typeof(ET.Server.Soul))]
    public static partial class SoulSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Soul self, int configId)
        {
            self.ConfigId = configId;
            self.Level = 1;
            self.Star = 1;
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.Soul self)
        {
        }

        public static SoulInfo ToMessage(this Soul self)
        {
            SoulInfo info = SoulInfo.Create();
            info.Id = self.Id;
            info.ConfigId = self.ConfigId;
            info.Level = self.Level;
            info.Star = self.Star;

            return info;
        }

        /// <summary>
        /// 初始化灵相关属性
        /// </summary>
        /// <param name="self"></param>
        public static void Initialization(this Soul self)
        {
            NumericComponent numericComponent = self.AddComponent<NumericComponent>();

            // 等级属性
            SoulLevelConfig levelConfig = SoulLevelConfigCategory.Instance.Get(self.ConfigId, self.Level);
            if (levelConfig != null)
            {
                numericComponent.AddPropertyPack(levelConfig.PropertyPack);
            }

            // 星级属性
            SoulStarConfig starConfig = SoulStarConfigCategory.Instance.Get(self.ConfigId, self.Star);
            if (starConfig != null)
            {
                numericComponent.AddPropertyPack(starConfig.PropertyPack);
            }
        }

        #region 升级

        public static int Uplevel(this Soul self)
        {
            Unit unit = self.GetParent<SoulComponent>().GetParent<Unit>();

            SoulLevelConfig config = SoulLevelConfigCategory.Instance.Get(self.ConfigId, self.Level);
            if (config == null)
            {
                return ErrorCode.ERR_SoulLevelConfigNotFound;
            }

            if (config.CurrencyValue < 1)
            {
                return ErrorCode.ERR_SoulLevelLimit;
            }

            bool ret = unit.GetComponent<CurrencyComponent>().Dec(config.CurrencyType, config.CurrencyValue, "灵升级");
            if (!ret)
            {
                return ErrorCode.ERR_CurrencyNotEnough;
            }

            self.Level += 1;

            return ErrorCode.ERR_Success;
        }

        #endregion

        #region 升星

        public static int Upstar(this Soul self)
        {
            return ErrorCode.ERR_Success;
        }

        #endregion
    }
}