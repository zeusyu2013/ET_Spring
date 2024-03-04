
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
    public sealed partial class UIGroupSubConfig : BeanBase
    {
        public UIGroupSubConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            GroupId = _buf.ReadInt();
            PanelName = _buf.ReadString();
            Open = _buf.ReadBool();
            Args = _buf.ReadInt();

            PostInit();
        }

        public static UIGroupSubConfig DeserializeUIGroupSubConfig(ByteBuf _buf)
        {
            return new UIGroupSubConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 组Id
        /// </summary>
        public readonly int GroupId;

        /// <summary>
        /// 组Id
        /// </summary>
        public UIGroupConfig GroupIdConfig => UIGroupConfigCategory.Instance.GetOrDefault(Args);

        /// <summary>
        /// 界面名字
        /// </summary>
        public readonly string PanelName;

        /// <summary>
        /// 是否打开
        /// </summary>
        public readonly bool Open;

        /// <summary>
        /// 界面初始化参数
        /// </summary>
        public readonly int Args;

        public const int __ID__ = -412464745;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "GroupId:" + GroupId + ","
            + "PanelName:" + PanelName + ","
            + "Open:" + Open + ","
            + "Args:" + Args + ","
            + "}";
        }

        partial void PostInit();
    }
}
