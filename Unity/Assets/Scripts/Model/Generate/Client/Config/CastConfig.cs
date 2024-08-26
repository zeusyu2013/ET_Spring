
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
    public sealed partial class CastConfig : BeanBase
    {
        public CastConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            TotalTime = _buf.ReadLong();
            CastCooldown = _buf.ReadInt();
            Casting = _buf.ReadBool();
            SelectTargetType = (SelectTargetType)_buf.ReadInt();
            CastTargetType = (CastTargetType)_buf.ReadInt();
            SelectTargetsParams = SelectTargetsParams.DeserializeSelectTargetsParams(_buf);
            NotifyType = (MessageNotifyType)_buf.ReadInt();

            PostInit();
        }

        public static CastConfig DeserializeCastConfig(ByteBuf _buf)
        {
            return new CastConfig(_buf);
        }

        /// <summary>
        /// 技能编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 技能总时长
        /// </summary>
        public readonly long TotalTime;

        /// <summary>
        /// 技能释放CD
        /// </summary>
        public readonly int CastCooldown;

        /// <summary>
        /// 持续施法
        /// </summary>
        public readonly bool Casting;

        /// <summary>
        /// 技能选择目标类型
        /// </summary>
        public readonly SelectTargetType SelectTargetType;

        /// <summary>
        /// 技能释放阵营
        /// </summary>
        public readonly CastTargetType CastTargetType;

        public readonly SelectTargetsParams SelectTargetsParams;

        /// <summary>
        /// 通知客户端方式
        /// </summary>
        public readonly MessageNotifyType NotifyType;

        public const int __ID__ = 944053121;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "TotalTime:" + TotalTime + ","
            + "CastCooldown:" + CastCooldown + ","
            + "Casting:" + Casting + ","
            + "SelectTargetType:" + SelectTargetType + ","
            + "CastTargetType:" + CastTargetType + ","
            + "SelectTargetsParams:" + SelectTargetsParams + ","
            + "NotifyType:" + NotifyType + ","
            + "}";
        }

        partial void PostInit();
    }
}
