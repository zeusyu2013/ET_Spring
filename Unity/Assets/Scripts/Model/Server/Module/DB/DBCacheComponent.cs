using System;
using System.Collections.Generic;

namespace ET.Server
{
    public class DBCacheComponent: Entity, IAwake
    {
        public long TimerId;

        public Dictionary<long, long> LRUDict;
        public Dictionary<long, Dictionary<Type, EntityRef<Entity>>> CacheDict;
    }
}