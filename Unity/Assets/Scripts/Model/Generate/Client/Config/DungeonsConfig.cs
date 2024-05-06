
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
    public sealed partial class DungeonsConfig : BeanBase
    {
        public DungeonsConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Scene = _buf.ReadInt();
            PreStage = _buf.ReadInt();

            PostInit();
        }

        public static DungeonsConfig DeserializeDungeonsConfig(ByteBuf _buf)
        {
            return new DungeonsConfig(_buf);
        }

        /// <summary>
        /// 编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 地下城场景编号
        /// </summary>
        public readonly int Scene;

        /// <summary>
        /// 地下城场景编号
        /// </summary>
        public SceneConfig SceneConfig => SceneConfigCategory.Instance.GetOrDefault(Scene);

        /// <summary>
        /// 前置地下城编号
        /// </summary>
        public readonly int PreStage;

        public const int __ID__ = -1063478853;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Scene:" + Scene + ","
            + "PreStage:" + PreStage + ","
            + "}";
        }

        partial void PostInit();
    }
}
