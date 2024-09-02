
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
    public sealed partial class RewardConfig : BeanBase
    {
        public RewardConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Reward = new System.Collections.Generic.Dictionary<int, long>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { int _k0;  _k0 = _buf.ReadInt(); long _v0;  _v0 = _buf.ReadLong();     Reward.Add(_k0, _v0);}}

            PostInit();
        }

        public static RewardConfig DeserializeRewardConfig(ByteBuf _buf)
        {
            return new RewardConfig(_buf);
        }

        /// <summary>
        /// 奖励包id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 奖励包名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 奖励包内容
        /// </summary>
        public readonly System.Collections.Generic.Dictionary<int, long> Reward;

        public const int __ID__ = 1443672945;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Reward:" + Luban.StringUtil.CollectionToString(Reward) + ","
            + "}";
        }

        partial void PostInit();
    }
}