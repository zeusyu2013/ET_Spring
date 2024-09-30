
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
    public sealed partial class SoulActionConfig : BeanBase
    {
        public SoulActionConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Type = (SoulActionType)_buf.ReadInt();
            ActionParams = ActionParam.DeserializeActionParam(_buf);

            PostInit();
        }

        public static SoulActionConfig DeserializeSoulActionConfig(ByteBuf _buf)
        {
            return new SoulActionConfig(_buf);
        }

        /// <summary>
        /// 行为编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 行为类型
        /// </summary>
        public readonly SoulActionType Type;

        public readonly ActionParam ActionParams;

        public const int __ID__ = 975906507;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Type:" + Type + ","
            + "ActionParams:" + ActionParams + ","
            + "}";
        }

        partial void PostInit();
    }
}