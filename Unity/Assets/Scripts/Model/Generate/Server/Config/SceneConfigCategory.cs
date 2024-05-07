
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
    /// 场景配置表
    /// </summary>
    [Config]
    public partial class SceneConfigCategory : Singleton<SceneConfigCategory>
    {
        private readonly Dictionary<int, SceneConfig> _dataMap;
        private readonly List<SceneConfig> _dataList;

        public SceneConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, SceneConfig>();
            _dataList = new List<SceneConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                SceneConfig _v;
                _v = SceneConfig.DeserializeSceneConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, SceneConfig> DataMap => _dataMap;
        public List<SceneConfig> DataList => _dataList;

        public SceneConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public SceneConfig Get(int key) => _dataMap[key];
        public SceneConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}