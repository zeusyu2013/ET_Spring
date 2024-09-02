
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
            EquipmentType = (EquipmentType)_buf.ReadInt();
            Base = _buf.ReadInt();
            Random = _buf.ReadInt();
            CharacterFlag = (CharacterType)_buf.ReadInt();

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
        /// 装备位置
        /// </summary>
        public readonly EquipmentType EquipmentType;

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

        /// <summary>
        /// 装备对应职业
        /// </summary>
        public readonly CharacterType CharacterFlag;

        public const int __ID__ = -824956336;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "EquipmentType:" + EquipmentType + ","
            + "Base:" + Base + ","
            + "Random:" + Random + ","
            + "CharacterFlag:" + CharacterFlag + ","
            + "}";
        }

        partial void PostInit();
    }
}