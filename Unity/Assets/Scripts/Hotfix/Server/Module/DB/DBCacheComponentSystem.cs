using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(DBCacheComponent))]
    [FriendOfAttribute(typeof(ET.Server.DBCacheComponent))]
    public static partial class DBCacheComponentSystem
    {
        [Invoke(TimerInvokeType.DBCacheTimer)]
        public class DBCacheTimer : ATimer<DBCacheComponent>
        {
            protected override void Run(DBCacheComponent self)
            {
                self.DBCacheUpdate();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.DBCacheComponent self)
        {
            self.TimerId = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(60 * 1000, TimerInvokeType.DBCacheTimer, self);
            self.CacheDict = new();
            self.LRUDict = new();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DBCacheComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);
            self.CacheDict.Clear();
            self.LRUDict.Clear();
        }

        public static async ETTask<T> Query<T>(this DBCacheComponent self, long playerId) where T : Entity
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DBCache, playerId))
            {
                if (!self.CacheDict.ContainsKey(playerId))
                {
                    T entity = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<T>(playerId);
                    self.AddCache<T>(playerId, entity);
                    return entity;
                }

                if (!self.CacheDict[playerId].ContainsKey(typeof(T)))
                {
                    T entity = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<T>(playerId);
                    self.AddCache<T>(playerId, entity);
                    return entity;
                }

                return (T)self.CacheDict[playerId][typeof(T)];
            }
        }

        public static async ETTask Save<T>(this DBCacheComponent self, T entity) where T : Entity
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DBCache, entity.Id))
            {
                if (!self.CacheDict.ContainsKey(entity.Id))
                {
                    self.AddCache(entity.Id, entity);
                }
                else
                {
                    self.UpdateCache(entity.Id, entity);
                }

                await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(entity);
            }
        }

        private static void AddCache<T>(this DBCacheComponent self, long playerId, T entity) where T : Entity
        {
            if (!self.LRUDict.ContainsKey(playerId))
            {
                self.LRUDict.Add(playerId, TimeInfo.Instance.ServerNow());
            }

            self.LRUDict[playerId] = TimeInfo.Instance.ServerNow();

            if (!self.CacheDict.ContainsKey(playerId))
            {
                self.CacheDict.Add(playerId, new Dictionary<Type, EntityRef<Entity>>());
            }

            if (!self.CacheDict[playerId].ContainsKey(typeof(T)))
            {
                self.CacheDict[playerId].Add(typeof(T), entity);
            }
        }

        private static void UpdateCache<T>(this DBCacheComponent self, long playerId, T entity) where T : Entity
        {
            if (self.CacheDict[playerId].ContainsKey(typeof(T)))
            {
                self.CacheDict[playerId][typeof(T)] = entity;
            }
            else
            {
                self.CacheDict[playerId].Add(typeof(T), entity);
            }

            self.LRUDict[playerId] = TimeInfo.Instance.ServerNow();
        }

        private static void RemoveCache(this DBCacheComponent self, long playerId)
        {
            if (!self.CacheDict.ContainsKey(playerId))
            {
                return;
            }

            self.CacheDict.Remove(playerId);
            self.LRUDict.Remove(playerId);
        }

        private static void DBCacheUpdate(this DBCacheComponent self)
        {
            long time = TimeInfo.Instance.ServerNow();
            List<long> keys = self.LRUDict.Keys.ToList();

            for (int i = keys.Count - 1; i > 0; --i)
            {
                long lastSaveTime = self.LRUDict[keys[i]];
                if (lastSaveTime - time < 24 * 60 * 1000)
                {
                    continue;
                }

                self.RemoveCache(keys[i]);
                self.LRUDict.Remove(keys[i]);
            }
        }
    }
}