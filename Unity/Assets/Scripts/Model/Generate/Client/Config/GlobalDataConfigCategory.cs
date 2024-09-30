
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 全局配置表
    /// </summary>
    [Config]
    public partial class GlobalDataConfigCategory : Singleton<GlobalDataConfigCategory>
    {

        private readonly GlobalDataConfig _data;

        public GlobalDataConfigCategory(ByteBuf _buf)
        {
            int n = _buf.ReadSize();
            if (n != 1) throw new SerializationException("table mode=one, but size != 1");
            _data = GlobalDataConfig.DeserializeGlobalDataConfig(_buf);
        }


        /// <summary>
        /// 时区
        /// </summary>
        public int TimeZone => _data.TimeZone;
        /// <summary>
        /// 背包初始容量
        /// </summary>
        public int BagCapacity => _data.BagCapacity;
        /// <summary>
        /// 背包最大容量
        /// </summary>
        public int BagMaxCapacity => _data.BagMaxCapacity;
        /// <summary>
        /// 相机最近距离
        /// </summary>
        public float CameraMinDistance => _data.CameraMinDistance;
        /// <summary>
        /// 相机最远距离
        /// </summary>
        public float CameraMaxDistance => _data.CameraMaxDistance;
        /// <summary>
        /// 创角数量限制
        /// </summary>
        public int CreateRoleMaxLimit => _data.CreateRoleMaxLimit;
        /// <summary>
        /// 重置天赋货币
        /// </summary>
        public int ResetTalentCurrency => _data.ResetTalentCurrency;
        /// <summary>
        /// 重置天赋货币值
        /// </summary>
        public long ResetTalentCurrencyValue => _data.ResetTalentCurrencyValue;
        /// <summary>
        /// 背包扩容道具id
        /// </summary>
        public int ExtendBagItemConfig => _data.ExtendBagItemConfig;
        /// <summary>
        /// 背包扩展个数
        /// </summary>
        public int ExtendBagCapacity => _data.ExtendBagCapacity;
        /// <summary>
        /// 小队队员最大数量
        /// </summary>
        public int TeamMemberLimit => _data.TeamMemberLimit;
        /// <summary>
        /// 体力上限
        /// </summary>
        public int DungeonConsumeMax => _data.DungeonConsumeMax;
        /// <summary>
        /// 体力恢复间隔
        /// </summary>
        public long DungeonConsumeRecoverInterval => _data.DungeonConsumeRecoverInterval;
        /// <summary>
        /// 体力恢复值
        /// </summary>
        public int DungeonConsumeRecoverValue => _data.DungeonConsumeRecoverValue;
        /// <summary>
        /// 战斗条最大长度
        /// </summary>
        public int BattleTotalProgress => _data.BattleTotalProgress;


        partial void PostInit();
    }
}
