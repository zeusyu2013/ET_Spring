
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
    public sealed partial class UnitConfig : BeanBase
    {
        public UnitConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Type = (NpcType)_buf.ReadInt();
            Name = _buf.ReadString();
            Model = _buf.ReadString();
            AI = _buf.ReadInt();
            Property = _buf.ReadInt();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Skills = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); Skills.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Drops = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); Drops.Add(_e0);}}

            PostInit();
        }

        public static UnitConfig DeserializeUnitConfig(ByteBuf _buf)
        {
            return new UnitConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// Npc类型
        /// </summary>
        public readonly NpcType Type;

        /// <summary>
        /// 名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 模型
        /// </summary>
        public readonly string Model;

        /// <summary>
        /// Ref测试
        /// </summary>
        public readonly int AI;

        /// <summary>
        /// Ref测试
        /// </summary>
        public AIConfig AIConfig => AIConfigCategory.Instance.GetOrDefault(AI);

        /// <summary>
        /// 属性包id
        /// </summary>
        public readonly int Property;

        /// <summary>
        /// 属性包id
        /// </summary>
        public PropertyConfig PropertyConfig => PropertyConfigCategory.Instance.GetOrDefault(Property);

        /// <summary>
        /// 技能列表
        /// </summary>
        public readonly System.Collections.Generic.List<int> Skills;

        /// <summary>
        /// 死亡掉落包
        /// </summary>
        public readonly System.Collections.Generic.List<int> Drops;

        public const int __ID__ = -568528378;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Type:" + Type + ","
            + "Name:" + Name + ","
            + "Model:" + Model + ","
            + "AI:" + AI + ","
            + "Property:" + Property + ","
            + "Skills:" + Luban.StringUtil.CollectionToString(Skills) + ","
            + "Drops:" + Luban.StringUtil.CollectionToString(Drops) + ","
            + "}";
        }

        partial void PostInit();
    }
}
