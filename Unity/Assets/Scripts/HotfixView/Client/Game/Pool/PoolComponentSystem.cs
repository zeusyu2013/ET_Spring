using PathologicalGames;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(PoolComponent))]
    [FriendOfAttribute(typeof(ET.Client.PoolComponent))]
    public static partial class PoolComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.PoolComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.PoolComponent self)
        {
        }

        public static SpawnPool GetPool(this PoolComponent self, string poolName, Transform prefab)
        {
            if (self.Pools.TryGetValue(poolName, out SpawnPool spawnPool))
            {
                return spawnPool;
            }

            SpawnPool pool = PoolManager.Pools.Create(poolName);
            pool.group.parent = self.Root().GetComponent<GlobalComponent>().Pool;
            pool.group.localPosition = Vector3.zero;
            pool.group.localRotation = Quaternion.identity;

            PrefabPool prefabPool = new(prefab);
            prefabPool.preloadAmount = 5;
            prefabPool.cullDespawned = true;
            prefabPool.cullAbove = 10;
            prefabPool.cullDelay = 1;
            prefabPool.limitInstances = true;
            prefabPool.limitAmount = 5;
            prefabPool.limitFIFO = true;

            pool.CreatePrefabPool(prefabPool);

            self.Pools.Add(poolName, pool);

            return pool;
        }

        public static Transform Spawn(this PoolComponent self, string poolName, Transform prefab, Transform parent)
        {
            return self.GetPool(poolName, prefab).Spawn(prefab, Vector3.zero, Quaternion.identity, parent);
        }

        public static void Despawn(this PoolComponent self, string poolName, Transform prefab)
        {
            self.GetPool(poolName, prefab).Despawn(prefab);
        }

        public static void DespawnAll(this PoolComponent self, string poolName, Transform prefab)
        {
            self.GetPool(poolName, prefab).DespawnAll();
        }
    }
}