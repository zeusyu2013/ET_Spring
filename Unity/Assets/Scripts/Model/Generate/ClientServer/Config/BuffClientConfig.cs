
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
    public sealed partial class BuffClientConfig : BeanBase
    {
        public BuffClientConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            if(_buf.ReadBool()){ AddFx = _buf.ReadString(); } else { AddFx = null; }
            AddFxBindPoint = (ModelBindPoint)_buf.ReadInt();
            AddFxTime = _buf.ReadLong();
            if(_buf.ReadBool()){ TickFx = _buf.ReadString(); } else { TickFx = null; }
            TickFxBindPoint = (ModelBindPoint)_buf.ReadInt();
            TickFxTime = _buf.ReadLong();
            if(_buf.ReadBool()){ RemoveFx = _buf.ReadString(); } else { RemoveFx = null; }
            RemoveFxBindPoint = (ModelBindPoint)_buf.ReadInt();
            RemoveFxTime = _buf.ReadLong();

            PostInit();
        }

        public static BuffClientConfig DeserializeBuffClientConfig(ByteBuf _buf)
        {
            return new BuffClientConfig(_buf);
        }

        /// <summary>
        /// 编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 编号
        /// </summary>
        public BuffConfig IdConfig => BuffConfigCategory.Instance.GetOrDefault(Id);

        /// <summary>
        /// buff添加特效
        /// </summary>
        public readonly string AddFx;

        /// <summary>
        /// buff添加特效绑点
        /// </summary>
        public readonly ModelBindPoint AddFxBindPoint;

        /// <summary>
        /// buff添加特效时长
        /// </summary>
        public readonly long AddFxTime;

        /// <summary>
        /// bufftick特效
        /// </summary>
        public readonly string TickFx;

        /// <summary>
        /// bufftick特效绑点
        /// </summary>
        public readonly ModelBindPoint TickFxBindPoint;

        /// <summary>
        /// bufftick特效时长
        /// </summary>
        public readonly long TickFxTime;

        /// <summary>
        /// buff移除特效
        /// </summary>
        public readonly string RemoveFx;

        /// <summary>
        /// buff移除特效绑点
        /// </summary>
        public readonly ModelBindPoint RemoveFxBindPoint;

        /// <summary>
        /// buff移除特效时长
        /// </summary>
        public readonly long RemoveFxTime;

        public const int __ID__ = -666426624;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "AddFx:" + AddFx + ","
            + "AddFxBindPoint:" + AddFxBindPoint + ","
            + "AddFxTime:" + AddFxTime + ","
            + "TickFx:" + TickFx + ","
            + "TickFxBindPoint:" + TickFxBindPoint + ","
            + "TickFxTime:" + TickFxTime + ","
            + "RemoveFx:" + RemoveFx + ","
            + "RemoveFxBindPoint:" + RemoveFxBindPoint + ","
            + "RemoveFxTime:" + RemoveFxTime + ","
            + "}";
        }

        partial void PostInit();
    }
}
