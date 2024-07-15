
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
    /// 属性分数配置
    /// </summary>
    [Config]
    public partial class PropertyScoreConfigCategory : Singleton<PropertyScoreConfigCategory>
    {
        private readonly Dictionary<GamePropertyType, PropertyScoreConfig> _dataMap;
        private readonly List<PropertyScoreConfig> _dataList;

        public PropertyScoreConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<GamePropertyType, PropertyScoreConfig>();
            _dataList = new List<PropertyScoreConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                PropertyScoreConfig _v;
                _v = PropertyScoreConfig.DeserializePropertyScoreConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<GamePropertyType, PropertyScoreConfig> DataMap => _dataMap;
        public List<PropertyScoreConfig> DataList => _dataList;

        public PropertyScoreConfig GetOrDefault(GamePropertyType key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public PropertyScoreConfig Get(GamePropertyType key) => _dataMap[key];
        public PropertyScoreConfig this[GamePropertyType key] => _dataMap[key];

        partial void PostInit();
    }
}