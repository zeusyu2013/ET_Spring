
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

        public const int __ID__ = -568528378;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Type:" + Type + ","
            + "Name:" + Name + ","
            + "Model:" + Model + ","
            + "}";
        }

        partial void PostInit();
    }
}
