
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
    public sealed partial class SkillConfig : BeanBase
    {
        public SkillConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Level = _buf.ReadInt();
            Base = _buf.ReadLong();
            Ratio = _buf.ReadLong();
            SkillRange = (SkillRange)_buf.ReadInt();
            Consume = _buf.ReadLong();

            PostInit();
        }

        public static SkillConfig DeserializeSkillConfig(ByteBuf _buf)
        {
            return new SkillConfig(_buf);
        }

        /// <summary>
        /// 技能编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 技能等级
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// 基础伤害/治疗值
        /// </summary>
        public readonly long Base;

        /// <summary>
        /// 附加百分比值
        /// </summary>
        public readonly long Ratio;

        /// <summary>
        /// 技能作用范围
        /// </summary>
        public readonly SkillRange SkillRange;

        /// <summary>
        /// 技能消耗
        /// </summary>
        public readonly long Consume;

        public const int __ID__ = -844226349;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Level:" + Level + ","
            + "Base:" + Base + ","
            + "Ratio:" + Ratio + ","
            + "SkillRange:" + SkillRange + ","
            + "Consume:" + Consume + ","
            + "}";
        }

        partial void PostInit();
    }
}