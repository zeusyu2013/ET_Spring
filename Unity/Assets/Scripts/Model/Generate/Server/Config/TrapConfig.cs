
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
    public sealed partial class TrapConfig : BeanBase
    {
        public TrapConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            SelectTargetType = (SelectTargetType)_buf.ReadInt();
            SelectTargetsParam = SelectTargetsParams.DeserializeSelectTargetsParams(_buf);
            TotalTime = _buf.ReadInt();
            Interval = _buf.ReadInt();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);CreateActions = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); CreateActions.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);IntervalActions = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); IntervalActions.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);DestroyActions = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); DestroyActions.Add(_e0);}}
            TickLimit = _buf.ReadInt();

            PostInit();
        }

        public static TrapConfig DeserializeTrapConfig(ByteBuf _buf)
        {
            return new TrapConfig(_buf);
        }

        /// <summary>
        /// 陷阱编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 选择目标类型
        /// </summary>
        public readonly SelectTargetType SelectTargetType;

        public readonly SelectTargetsParams SelectTargetsParam;

        /// <summary>
        /// 持续时长
        /// </summary>
        public readonly int TotalTime;

        /// <summary>
        /// 结算间隔
        /// </summary>
        public readonly int Interval;

        /// <summary>
        /// 创建时触发行为
        /// </summary>
        public readonly System.Collections.Generic.List<int> CreateActions;

        /// <summary>
        /// 结算时行为
        /// </summary>
        public readonly System.Collections.Generic.List<int> IntervalActions;

        /// <summary>
        /// 销毁前触发行为
        /// </summary>
        public readonly System.Collections.Generic.List<int> DestroyActions;

        /// <summary>
        /// 结算次数限制
        /// </summary>
        public readonly int TickLimit;

        public const int __ID__ = 675473647;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "SelectTargetType:" + SelectTargetType + ","
            + "SelectTargetsParam:" + SelectTargetsParam + ","
            + "TotalTime:" + TotalTime + ","
            + "Interval:" + Interval + ","
            + "CreateActions:" + Luban.StringUtil.CollectionToString(CreateActions) + ","
            + "IntervalActions:" + Luban.StringUtil.CollectionToString(IntervalActions) + ","
            + "DestroyActions:" + Luban.StringUtil.CollectionToString(DestroyActions) + ","
            + "TickLimit:" + TickLimit + ","
            + "}";
        }

        partial void PostInit();
    }
}
