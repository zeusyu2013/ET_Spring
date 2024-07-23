
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
    [EnableClass]
    public sealed partial class LotteryConfig : BeanBase
    {
        public LotteryConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);LotteryInfos = new System.Collections.Generic.Dictionary<LotteryQuality, int>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { LotteryQuality _k0;  _k0 = (LotteryQuality)_buf.ReadInt(); int _v0;  _v0 = _buf.ReadInt();     LotteryInfos.Add(_k0, _v0);}}
            UpgradeCurrencyType = (CurrencyType)_buf.ReadInt();
            UpgradeCurrencyValue = _buf.ReadLong();
            UpgradeBuildingConfig = _buf.ReadInt();
            UpgradeBuildingLevel = _buf.ReadInt();

            PostInit();
        }

        public static LotteryConfig DeserializeLotteryConfig(ByteBuf _buf)
        {
            return new LotteryConfig(_buf);
        }

        /// <summary>
        /// 宝箱等级
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 宝箱品质
        /// </summary>
        public readonly System.Collections.Generic.Dictionary<LotteryQuality, int> LotteryInfos;

        /// <summary>
        /// 升级所需货币类型
        /// </summary>
        public readonly CurrencyType UpgradeCurrencyType;

        /// <summary>
        /// 升级所需货币值
        /// </summary>
        public readonly long UpgradeCurrencyValue;

        /// <summary>
        /// 升级所需建筑
        /// </summary>
        public readonly int UpgradeBuildingConfig;

        /// <summary>
        /// 升级所需建筑
        /// </summary>
        public BuildingConfig UpgradeBuildingConfigConfig => BuildingConfigCategory.Instance.GetOrDefault(UpgradeBuildingConfig);

        /// <summary>
        /// 升级所需建筑等级
        /// </summary>
        public readonly int UpgradeBuildingLevel;

        public const int __ID__ = -2003756085;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "LotteryInfos:" + Luban.StringUtil.CollectionToString(LotteryInfos) + ","
            + "UpgradeCurrencyType:" + UpgradeCurrencyType + ","
            + "UpgradeCurrencyValue:" + UpgradeCurrencyValue + ","
            + "UpgradeBuildingConfig:" + UpgradeBuildingConfig + ","
            + "UpgradeBuildingLevel:" + UpgradeBuildingLevel + ","
            + "}";
        }

        partial void PostInit();
    }
}
