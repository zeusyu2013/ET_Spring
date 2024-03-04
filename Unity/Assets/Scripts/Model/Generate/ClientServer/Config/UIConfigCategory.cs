
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
    [Config]
    public partial class UIConfigCategory : Singleton<UIConfigCategory>
    {
        private readonly Dictionary<int, UIConfig> _dataMap;
        private readonly List<UIConfig> _dataList;

        public UIConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, UIConfig>();
            _dataList = new List<UIConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                UIConfig _v;
                _v = UIConfig.DeserializeUIConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, UIConfig> DataMap => _dataMap;
        public List<UIConfig> DataList => _dataList;

        public UIConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public UIConfig Get(int key) => _dataMap[key];
        public UIConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}
