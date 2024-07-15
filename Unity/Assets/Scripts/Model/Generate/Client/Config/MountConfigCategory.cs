
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
    /// 坐骑配置
    /// </summary>
    [Config]
    public partial class MountConfigCategory : Singleton<MountConfigCategory>
    {
        private readonly Dictionary<int, MountConfig> _dataMap;
        private readonly List<MountConfig> _dataList;

        public MountConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, MountConfig>();
            _dataList = new List<MountConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                MountConfig _v;
                _v = MountConfig.DeserializeMountConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, MountConfig> DataMap => _dataMap;
        public List<MountConfig> DataList => _dataList;

        public MountConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        public MountConfig Get(int key) => _dataMap[key];
        public MountConfig this[int key] => _dataMap[key];

        partial void PostInit();
    }
}
