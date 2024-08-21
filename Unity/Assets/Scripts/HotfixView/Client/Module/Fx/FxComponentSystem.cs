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
    }
}