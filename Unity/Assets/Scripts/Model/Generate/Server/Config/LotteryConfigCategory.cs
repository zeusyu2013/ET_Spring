
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
    /// 抽宝配置
    /// </summary>
    [Config]
    public partial class LotteryConfigCategory : Singleton<LotteryConfigCategory>
    {
        private readonly Dictionary<int, LotteryConfig> _dataMap;
        private readonly List<LotteryConfig> _dataList;

        public LotteryConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, LotteryConfig>();
            _dataList = new List<LotteryConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                LotteryConfig _v;
                _v = LotteryConfig.DeserializeLotteryConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, LotteryConfig> DataMap => _dataMap;
        public List<LotteryConfig> DataList => _dataList;

        public LotteryConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public LotteryConfig Get(int key) => _dataMap[key];
        public LotteryConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}