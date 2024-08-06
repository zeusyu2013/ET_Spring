
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
    /// 技能行为配置表
    /// </summary>
    [Config]
    public partial class ActionConfigCategory : Singleton<ActionConfigCategory>
    {
        private readonly Dictionary<int, ActionConfig> _dataMap;
        private readonly List<ActionConfig> _dataList;

        public ActionConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, ActionConfig>();
            _dataList = new List<ActionConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                ActionConfig _v;
                _v = ActionConfig.DeserializeActionConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, ActionConfig> DataMap => _dataMap;
        public List<ActionConfig> DataList => _dataList;

        public ActionConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public ActionConfig Get(int key) => _dataMap[key];
        public ActionConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}