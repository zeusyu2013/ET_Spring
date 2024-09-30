
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
    /// 7日奖励配置
    /// </summary>
    [Config]
    public partial class SevenDayConfigCategory : Singleton<SevenDayConfigCategory>
    {
        private readonly Dictionary<int, SevenDayConfig> _dataMap;
        private readonly List<SevenDayConfig> _dataList;

        public SevenDayConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, SevenDayConfig>();
            _dataList = new List<SevenDayConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                SevenDayConfig _v;
                _v = SevenDayConfig.DeserializeSevenDayConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, SevenDayConfig> DataMap => _dataMap;
        public List<SevenDayConfig> DataList => _dataList;

        public SevenDayConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public SevenDayConfig Get(int key) => _dataMap[key];
        public SevenDayConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}