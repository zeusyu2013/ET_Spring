
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
    public sealed partial class SceneNpcConfig : BeanBase
    {
        public SceneNpcConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Position = vec3.Deserializevec3(_buf);

            PostInit();
        }

        public static SceneNpcConfig DeserializeSceneNpcConfig(ByteBuf _buf)
        {
            return new SceneNpcConfig(_buf);
        }

        /// <summary>
        /// Npc编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// Npc编号
        /// </summary>
        public UnitConfig IdConfig => UnitConfigCategory.Instance.GetOrDefault(Id);

        /// <summary>
        /// 位置
        /// </summary>
        public readonly vec3 Position;

        public const int __ID__ = 1760779895;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Position:" + Position + ","
            + "}";
        }

        partial void PostInit();
    }
}