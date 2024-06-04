
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
    /// 装备宝石孔位配置
    /// </summary>
    [Config]
    public partial class EquipmentHoleConfigCategory : Singleton<EquipmentHoleConfigCategory>
    {
        private readonly Dictionary<int, EquipmentHoleConfig> _dataMap;
        private readonly List<EquipmentHoleConfig> _dataList;

        public EquipmentHoleConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, EquipmentHoleConfig>();
            _dataList = new List<EquipmentHoleConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                EquipmentHoleConfig _v;
                _v = EquipmentHoleConfig.DeserializeEquipmentHoleConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, EquipmentHoleConfig> DataMap => _dataMap;
        public List<EquipmentHoleConfig> DataList => _dataList;

        public EquipmentHoleConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public EquipmentHoleConfig Get(int key) => _dataMap[key];
        public EquipmentHoleConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}
