
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
    public sealed partial class OfflineIncomeConfig : BeanBase
    {
        public OfflineIncomeConfig(ByteBuf _buf)
        {
            Level = _buf.ReadInt();
            Exp = _buf.ReadLong();
            Gold = _buf.ReadLong();
            MaxTime = _buf.ReadLong();

            PostInit();
        }

        public static OfflineIncomeConfig DeserializeOfflineIncomeConfig(ByteBuf _buf)
        {
            return new OfflineIncomeConfig(_buf);
        }

        /// <summary>
        /// 等级
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// 每秒经验值
        /// </summary>
        public readonly long Exp;

        /// <summary>
        /// 每秒金币
        /// </summary>
        public readonly long Gold;

        /// <summary>
        /// 最大时长
        /// </summary>
        public readonly long MaxTime;

        public const int __ID__ = -1723671634;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Level:" + Level + ","
            + "Exp:" + Exp + ","
            + "Gold:" + Gold + ","
            + "MaxTime:" + MaxTime + ","
            + "}";
        }

        partial void PostInit();
    }
}
