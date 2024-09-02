
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
    /// 场景Npc配置
    /// </summary>
    [Config]
    public partial class SceneNpcConfigCategory : Singleton<SceneNpcConfigCategory>
    {
        private readonly Dictionary<int, SceneNpcConfig> _dataMap;
        private readonly List<SceneNpcConfig> _dataList;

        public SceneNpcConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, SceneNpcConfig>();
            _dataList = new List<SceneNpcConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                SceneNpcConfig _v;
                _v = SceneNpcConfig.DeserializeSceneNpcConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, SceneNpcConfig> DataMap => _dataMap;
        public List<SceneNpcConfig> DataList => _dataList;

        public SceneNpcConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public SceneNpcConfig Get(int key) => _dataMap[key];
        public SceneNpcConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}