
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
    public sealed partial class AIConfig : BeanBase
    {
        public AIConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);AIInfos = new System.Collections.Generic.Dictionary<int, AIType>(n0 * 3 / 2);for(var i0 = 0 ; i0 < n0 ; i0++) { int _k0;  _k0 = _buf.ReadInt(); AIType _v0;  _v0 = (AIType)_buf.ReadInt();     AIInfos.Add(_k0, _v0);}}

            PostInit();
        }

        public static AIConfig DeserializeAIConfig(ByteBuf _buf)
        {
            return new AIConfig(_buf);
        }

        /// <summary>
        /// AI编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// AI节点信息
        /// </summary>
        public readonly System.Collections.Generic.Dictionary<int, AIType> AIInfos;

        public const int __ID__ = -294143606;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "AIInfos:" + Luban.StringUtil.CollectionToString(AIInfos) + ","
            + "}";
        }

        partial void PostInit();
    }
}
