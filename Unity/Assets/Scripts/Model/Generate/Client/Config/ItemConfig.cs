
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
    public sealed partial class ItemConfig : BeanBase
    {
        public ItemConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            Type = (GameItemType)_buf.ReadInt();
            Quality = (GameItemQualityType)_buf.ReadInt();
            UseLevel = _buf.ReadInt();
            Icon = _buf.ReadString();

            PostInit();
        }

        public static ItemConfig DeserializeItemConfig(ByteBuf _buf)
        {
            return new ItemConfig(_buf);
        }

        /// <summary>
        /// 道具id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 道具名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 道具类型
        /// </summary>
        public readonly GameItemType Type;

        /// <summary>
        /// 道具品质
        /// </summary>
        public readonly GameItemQualityType Quality;

        /// <summary>
        /// 道具使用等级限制
        /// </summary>
        public readonly int UseLevel;

        /// <summary>
        /// 道具图标
        /// </summary>
        public readonly string Icon;

        public const int __ID__ = -764023723;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Type:" + Type + ","
            + "Quality:" + Quality + ","
            + "UseLevel:" + UseLevel + ","
            + "Icon:" + Icon + ","
            + "}";
        }

        partial void PostInit();
    }
}
