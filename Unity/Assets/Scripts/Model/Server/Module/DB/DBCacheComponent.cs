using System;
using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class DBCacheComponent: Entity, IAwake, IDestroy
    {
        public long TimerId;
        public long SaveTimerId;

        public Dictionary<long, long> LRUDict;
        public Dictionary<long, Dictionary<Type, EntityRef<Entity>>> CacheDict;
    }
}