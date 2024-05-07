
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
    /// 地下城配置表
    /// </summary>
    [Config]
    public partial class DungeonsConfigCategory : Singleton<DungeonsConfigCategory>
    {
        private readonly Dictionary<int, DungeonsConfig> _dataMap;
        private readonly List<DungeonsConfig> _dataList;

        public DungeonsConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, DungeonsConfig>();
            _dataList = new List<DungeonsConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                DungeonsConfig _v;
                _v = DungeonsConfig.DeserializeDungeonsConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, DungeonsConfig> DataMap => _dataMap;
        public List<DungeonsConfig> DataList => _dataList;

        public DungeonsConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public DungeonsConfig Get(int key) => _dataMap[key];
        public DungeonsConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}