
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
    public sealed partial class MountConfig : BeanBase
    {
        public MountConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            Desc = _buf.ReadString();
            Model = _buf.ReadString();
            ActivationItem = _buf.ReadInt();
            SpeedRate = _buf.ReadLong();

            PostInit();
        }

        public static MountConfig DeserializeMountConfig(ByteBuf _buf)
        {
            return new MountConfig(_buf);
        }

        /// <summary>
        /// 坐骑编号
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 坐骑名
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 坐骑描述
        /// </summary>
        public readonly string Desc;

        /// <summary>
        /// 坐骑模型
        /// </summary>
        public readonly string Model;

        /// <summary>
        /// 激活道具
        /// </summary>
        public readonly int ActivationItem;

        /// <summary>
        /// 激活道具
        /// </summary>
        public ItemConfig ActivationItemConfig => ItemConfigCategory.Instance.GetOrDefault(ActivationItem);

        /// <summary>
        /// 移动速度百分比加成
        /// </summary>
        public readonly long SpeedRate;

        public const int __ID__ = -1952375653;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Desc:" + Desc + ","
            + "Model:" + Model + ","
            + "ActivationItem:" + ActivationItem + ","
            + "SpeedRate:" + SpeedRate + ","
            + "}";
        }

        partial void PostInit();
    }
}