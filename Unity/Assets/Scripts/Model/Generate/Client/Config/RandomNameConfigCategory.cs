
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
    /// 随机姓名配置
    /// </summary>
    [Config]
    public partial class RandomNameConfigCategory : Singleton<RandomNameConfigCategory>
    {
        private readonly Dictionary<int, RandomNameConfig> _dataMap;
        private readonly List<RandomNameConfig> _dataList;

        public RandomNameConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, RandomNameConfig>();
            _dataList = new List<RandomNameConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                RandomNameConfig _v;
                _v = RandomNameConfig.DeserializeRandomNameConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, RandomNameConfig> DataMap => _dataMap;
        public List<RandomNameConfig> DataList => _dataList;

        public RandomNameConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public RandomNameConfig Get(int key) => _dataMap[key];
        public RandomNameConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}