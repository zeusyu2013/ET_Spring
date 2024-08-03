
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
    public sealed partial class MonsterConfig : BeanBase
    {
        public MonsterConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            PropertyPack = _buf.ReadInt();
            AI = _buf.ReadInt();
            DropConfig = _buf.ReadInt();

            PostInit();
        }

        public static MonsterConfig DeserializeMonsterConfig(ByteBuf _buf)
        {
            return new MonsterConfig(_buf);
        }

        /// <summary>
        /// 编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 编号
        /// </summary>
        public UnitConfig IdConfig => UnitConfigCategory.Instance.GetOrDefault(Id);

        /// <summary>
        /// 怪物属性包
        /// </summary>
        public readonly int PropertyPack;

        /// <summary>
        /// 怪物属性包
        /// </summary>
        public PropertyConfig PropertyPackConfig => PropertyConfigCategory.Instance.GetOrDefault(PropertyPack);

        /// <summary>
        /// 怪物AI
        /// </summary>
        public readonly int AI;

        /// <summary>
        /// 怪物AI
        /// </summary>
        public AIConfig AIConfig => AIConfigCategory.Instance.GetOrDefault(AI);

        public readonly int DropConfig;

        public DropConfig DropConfigConfig => DropConfigCategory.Instance.GetOrDefault(DropConfig);

        public const int __ID__ = -55174244;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "PropertyPack:" + PropertyPack + ","
            + "AI:" + AI + ","
            + "DropConfig:" + DropConfig + ","
            + "}";
        }

        partial void PostInit();
    }
}
