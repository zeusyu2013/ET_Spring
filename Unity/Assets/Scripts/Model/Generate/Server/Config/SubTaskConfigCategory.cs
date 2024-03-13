
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
    /// 子任务配置表
    /// </summary>
    [Config]
    public partial class SubTaskConfigCategory : Singleton<SubTaskConfigCategory>
    {
        private readonly Dictionary<int, SubTaskConfig> _dataMap;
        private readonly List<SubTaskConfig> _dataList;

        public SubTaskConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, SubTaskConfig>();
            _dataList = new List<SubTaskConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                SubTaskConfig _v;
                _v = SubTaskConfig.DeserializeSubTaskConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, SubTaskConfig> DataMap => _dataMap;
        public List<SubTaskConfig> DataList => _dataList;

        public SubTaskConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public SubTaskConfig Get(int key) => _dataMap[key];
        public SubTaskConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}
