
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
    public sealed partial class VipConfig : BeanBase
    {
        public VipConfig(ByteBuf _buf)
        {
            VipLevel = _buf.ReadInt();
            Exp = _buf.ReadLong();
            OfflineRate = _buf.ReadLong();
            OfflineAddTime = _buf.ReadLong();
            Pack = _buf.ReadInt();

            PostInit();
        }

        public static VipConfig DeserializeVipConfig(ByteBuf _buf)
        {
            return new VipConfig(_buf);
        }

        /// <summary>
        /// Vip等级
        /// </summary>
        public readonly int VipLevel;

        /// <summary>
        /// Vip经验
        /// </summary>
        public readonly long Exp;

        /// <summary>
        /// 离线倍率
        /// </summary>
        public readonly long OfflineRate;

        /// <summary>
        /// 离线最大时长增加
        /// </summary>
        public readonly long OfflineAddTime;

        /// <summary>
        /// Vip礼包
        /// </summary>
        public readonly int Pack;

        /// <summary>
        /// Vip礼包
        /// </summary>
        public ItemConfig PackConfig => ItemConfigCategory.Instance.GetOrDefault(Pack);

        public const int __ID__ = 129437087;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "VipLevel:" + VipLevel + ","
            + "Exp:" + Exp + ","
            + "OfflineRate:" + OfflineRate + ","
            + "OfflineAddTime:" + OfflineAddTime + ","
            + "Pack:" + Pack + ","
            + "}";
        }

        partial void PostInit();
    }
}
