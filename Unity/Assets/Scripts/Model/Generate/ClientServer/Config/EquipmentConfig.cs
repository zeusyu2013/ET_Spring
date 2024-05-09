
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
    public sealed partial class EquipmentConfig : BeanBase
    {
        public EquipmentConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Base = _buf.ReadInt();
            Random = _buf.ReadInt();

            PostInit();
        }

        public static EquipmentConfig DeserializeEquipmentConfig(ByteBuf _buf)
        {
            return new EquipmentConfig(_buf);
        }

        /// <summary>
        /// 道具id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 道具id
        /// </summary>
        public ItemConfig IdConfig => ItemConfigCategory.Instance.GetOrDefault(Id);

        /// <summary>
        /// 基础属性包
        /// </summary>
        public readonly int Base;

        /// <summary>
        /// 基础属性包
        /// </summary>
        public PropertyConfig BaseConfig => PropertyConfigCategory.Instance.GetOrDefault(Base);

        /// <summary>
        /// 随机属性包
        /// </summary>
        public readonly int Random;

        /// <summary>
        /// 随机属性包
        /// </summary>
        public PropertyRandomConfig RandomConfig => PropertyRandomConfigCategory.Instance.GetOrDefault(Random);

        public const int __ID__ = -824956336;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Base:" + Base + ","
            + "Random:" + Random + ","
            + "}";
        }

        partial void PostInit();
    }
}
