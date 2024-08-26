using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(FxComponent))]
    [FriendOf(typeof(FxComponent))]
    public static partial class FxComponentSystem
    {
        [Invoke(TimerInvokeType.FxTimer)]
        public class FxRemoveTimer : ATimer<FxComponent>
        {
            protected override void Run(FxComponent self)
            {
                self.Check();
            }
        }

        [EntitySystem]
        private static void Awake(this FxComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.FxTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this FxComponent self)
        {
            self.Fxes.Clear();
            self.AddFxes.Clear();
            self.RemoveFxes.Clear();
        }

        private static void Add(this FxComponent self, string poolName, Transform fx, long time)
        {
            if (!self.AddFxes.ContainsKey(poolName))
            {
                self.AddFxes.Add(poolName, new Dictionary<Transform, long>());
            }

            self.AddFxes[poolName].Add(fx, time);
        }

        private static void Check(this FxComponent self)
        {
            if (self.AddFxes.Count > 0)
            {
                foreach (KeyValuePair<string, Dictionary<Transform, long>> kv in self.AddFxes)
                {
                    if (!self.Fxes.ContainsKey(kv.Key))
                    {
                        self.Fxes.Add(kv.Key, new Dictionary<Transform, long>());
                    }

                    foreach ((Transform transform, long time) in kv.Value)
                    {
                        self.Fxes[kv.Key].Add(transform, time);
                    }
                }

                self.AddFxes.Clear();
            }

            if (self.Fxes.Count < 1)
            {
                return;
            }

            long now = TimeInfo.Instance.ClientNow();
            foreach ((string poolName, Dictionary<Transform, long> dict) in self.Fxes)
            {
                foreach ((Transform transform, long time) in dict)
                {
                    if (time < now)
                    {
                        continue;
                    }

                    if (!self.RemoveFxes.ContainsKey(poolName))
                    {
                        self.RemoveFxes.Add(poolName, new List<Transform>());
                    }

                    self.RemoveFxes[poolName].Add(transform);
                }
            }

            foreach ((string poolName, List<Transform> transforms) in self.RemoveFxes)
            {
                if (!self.Fxes.ContainsKey(poolName))
                {
                    continue;
                }

                foreach (Transform transform in transforms)
                {
                    self.Fxes[poolName].Remove(transform);

                    self.Scene().GetComponent<PoolComponent>().Despawn(poolName, transform);
                }
            }

            self.RemoveFxes.Clear();
        }

        private static async ETTask<Transform> Spwan(this FxComponent self, string fxPath, Transform parent)
        {
            GameObject go = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(fxPath);

            Transform transform = self.Scene().GetComponent<PoolComponent>().Spawn(fxPath, go.transform, parent);

            return transform;
        }

        public static async ETTask PlayFx(this FxComponent self, Unit unit, string fxPath, ModelBindPoint point, long time)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            if (string.IsNullOrEmpty(fxPath))
            {
                return;
            }

            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            Transform bindPoint = gameObjectComponent.GetBindPoint(point);
            if (bindPoint == null)
            {
                bindPoint = gameObjectComponent.Transform;
            }

            // 播放特效
            Transform fx = await self.Spwan(fxPath, bindPoint);

            self.Add(fxPath, fx, TimeInfo.Instance.ClientNow() + time);
        }
    }
}