
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
    public sealed partial class UIConfig : BeanBase
    {
        public UIConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            UIType = _buf.ReadInt();
            Layer = _buf.ReadInt();
            FullScreen = _buf.ReadBool();
            RefitH = _buf.ReadBool();
            ChangeSceneRemove = _buf.ReadBool();

            PostInit();
        }

        public static UIConfig DeserializeUIConfig(ByteBuf _buf)
        {
            return new UIConfig(_buf);
        }

        /// <summary>
        /// Id
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 界面名字
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 界面类型
        /// </summary>
        public readonly int UIType;

        /// <summary>
        /// 层级
        /// </summary>
        public readonly int Layer;

        /// <summary>
        /// 全屏
        /// </summary>
        public readonly bool FullScreen;

        /// <summary>
        /// 刘海适配
        /// </summary>
        public readonly bool RefitH;

        /// <summary>
        /// 切场景时移除
        /// </summary>
        public readonly bool ChangeSceneRemove;

        public const int __ID__ = 202324726;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "UIType:" + UIType + ","
            + "Layer:" + Layer + ","
            + "FullScreen:" + FullScreen + ","
            + "RefitH:" + RefitH + ","
            + "ChangeSceneRemove:" + ChangeSceneRemove + ","
            + "}";
        }

        partial void PostInit();
    }
}