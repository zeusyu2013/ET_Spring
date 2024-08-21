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

        public static void Add(this FxComponent self, Transform fx, long time)
        {
            self.AddFxes.TryAdd(fx, time);
        }

        private static void Check(this FxComponent self)
        {
            if (self.AddFxes.Count > 0)
            {
                foreach ((Transform transform, long time) in self.AddFxes)
                {
                    self.Fxes[transform] = time;
                }

                self.AddFxes.Clear();
            }

            if (self.Fxes.Count < 1)
            {
                return;
            }

            long now = TimeInfo.Instance.ClientNow();
            foreach ((Transform transform, long time) in self.Fxes)
            {
                if (time < now)
                {
                    continue;
                }

                self.RemoveFxes.Add(transform);
            }

            foreach (Transform removeFx in self.RemoveFxes)
            {
                self.Fxes.Remove(removeFx);

                self.Scene().GetComponent<PoolComponent>().Despawn(removeFx.name, removeFx);
            }

            self.RemoveFxes.Clear();
        }

        public static async ETTask<Transform> Spwan(this FxComponent self, string fxPath, Transform parent)
        {
            GameObject go = await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(fxPath);

            Transform transform = self.Scene().GetComponent<PoolComponent>().Spawn(fxPath, go.transform, parent);

            return transform;
        }

        public static async ETTask PlayCastFx(this FxComponent self, Unit unit, int castConfigId)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            CastClientConfig config = CastClientConfigCategory.Instance.Get(castConfigId);
            string fxName = config.CastStartFx;
            if (string.IsNullOrEmpty(fxName))
            {
                return;
            }

            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            Transform bindPoint = gameObjectComponent.GetBindPoint(config.CastStartFxBindPoint);
            if (bindPoint == null)
            {
                bindPoint = gameObjectComponent.Transform;
            }

            // 播放特效
            Transform fx = await self.Spwan(fxName, bindPoint);

            self.Add(fx, TimeInfo.Instance.ClientNow() + config.CastStartFxTime);
        }

        public static async ETTask PlayBuffFx(this FxComponent self, Unit unit, int buffConfigId)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            BuffClientConfig config = BuffClientConfigCategory.Instance.Get(buffConfigId);
            string fxName = config.AddFx;
            if (string.IsNullOrEmpty(fxName))
            {
                return;
            }

            GameObjectComponent gameObjectComponent = unit.GetComponent<GameObjectComponent>();
            Transform bindPoint = gameObjectComponent.GetBindPoint(config.AddFxBindPoint);
            if (bindPoint == null)
            {
                bindPoint = gameObjectComponent.Transform;
            }

            // 播放特效
            Transform fx = await self.Spwan(fxName, bindPoint);

            self.Add(fx, TimeInfo.Instance.ClientNow() + config.AddFxTime);
        }

        public static async ETTask PlayFx(this FxComponent self, Unit unit, string fxPath, ModelBindPoint point, long time)
        {
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            string fxName = fxPath;
            if (string.IsNullOrEmpty(fxName))
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
            Transform fx = await self.Spwan(fxName, bindPoint);

            self.Add(fx, TimeInfo.Instance.ClientNow() + time);
        }
    }
}