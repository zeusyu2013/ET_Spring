using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(DBCacheComponent))]
    [EntitySystemOf(typeof(DBCacheComponent))]
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

        [Invoke(TimerInvokeType.DBCacheSaveTimer)]
        public class DBCacheSaveTimer : ATimer<DBCacheComponent>
        {
            protected override void Run(DBCacheComponent self)
            {
                self.DBCacheSave().Coroutine();
            }
        }

        [EntitySystem]
        private static void Awake(this DBCacheComponent self)
        {
            self.TimerId = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(60 * 1000, TimerInvokeType.DBCacheTimer, self);
            self.SaveTimerId = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(60 * 1000, TimerInvokeType.DBCacheSaveTimer, self);
            self.CacheDict = new();
            self.LRUDict = new();
        }

        [EntitySystem]
        private static void Destroy(this DBCacheComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerId);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.SaveTimerId);
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
                    self.UpdateCache(playerId, entity);
                    return entity;
                }

                if (!self.CacheDict[playerId].ContainsKey(typeof(T)))
                {
                    T entity = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<T>(playerId);
                    self.UpdateCache(playerId, entity);
                    return entity;
                }

                return (T)self.CacheDict[playerId][typeof(T)];
            }
        }

        public static async ETTask Save<T>(this DBCacheComponent self, T entity) where T : Entity
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DBCache, entity.Id))
            {
                self.UpdateCache(entity.Id, entity);
            }
        }

        public static void UpdateCache<T>(this DBCacheComponent self, long playerId, T entity) where T : Entity
        {
            if (self.LRUDict.ContainsKey(playerId))
            {
                self.LRUDict[playerId] = TimeInfo.Instance.ServerNow();
            }
            else
            {
                self.LRUDict.Add(playerId, TimeInfo.Instance.ServerNow());
            }

            if (self.CacheDict[playerId].ContainsKey(typeof(T)))
            {
                self.CacheDict[playerId][typeof(T)] = entity;
            }
            else
            {
                self.CacheDict[playerId].Add(typeof(T), entity);
            }
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

        public static async ETTask SaveUnit(this DBCacheComponent self, Entity unit)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            long id = unit.Id;
            if (self.CacheDict.ContainsKey(id))
            {
                using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DBCache, id))
                {
                    List<Entity> entities = new();
                    foreach (var entityRef in self.CacheDict[id].Values)
                    {
                        Entity entity = entityRef;
                        if (entity == null)
                        {
                            continue;
                        }

                        entities.Add(entity);
                    }

                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).InsertBatch(entities);
                }
            }
            else
            {
                using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, id))
                {
                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(unit);
                }
            }
        }

        private static void DBCacheUpdate(this DBCacheComponent self)
        {
            Log.Info("缓存更新中……");

            long time = TimeInfo.Instance.ServerNow();
            List<long> keys = self.LRUDict.Keys.ToList();

            for (int i = keys.Count - 1; i > 0; --i)
            {
                long lastSaveTime = self.LRUDict[keys[i]];
                if (lastSaveTime - time < 24 * 60 * 1000 * 1000)
                {
                    continue;
                }

                self.RemoveCache(keys[i]);
            }
        }

        private static async ETTask DBCacheSave(this DBCacheComponent self)
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DBCache, TimeInfo.Instance.ServerNow()))
            {
                List<Entity> entities = new();
                foreach (var entityRefs in self.CacheDict.Values)
                {
                    foreach (var kv in entityRefs)
                    {
                        entities.Add(kv.Value);
                    }
                }

                await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).InsertBatch(entities);
            }
        }
    }
}