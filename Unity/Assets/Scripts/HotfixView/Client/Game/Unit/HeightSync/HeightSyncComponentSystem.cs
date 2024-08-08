using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(HeightSyncComponent))]
    [FriendOfAttribute(typeof(ET.Client.HeightSyncComponent))]
    public static partial class HeightSyncComponentSystem
    {
        [Invoke(TimerInvokeType.HeightSyncTimer)]
        public class HeightSyncTimer : ATimer<HeightSyncComponent>
        {
            protected override void Run(HeightSyncComponent self)
            {
                self.Sync();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Client.HeightSyncComponent self)
        {
            self.MaxDistance = 100f;
            self.Results = new RaycastHit[5];
            self.Height = 0;
            self.LayerMask = LayerMask.GetMask("Ground");
            
            self.Sync();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(500, TimerInvokeType.HeightSyncTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.HeightSyncComponent self)
        {
            self.MaxDistance = default;
            self.LayerMask = default;
            self.Height = default;

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        private static void Sync(this ET.Client.HeightSyncComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit == null)
            {
                return;
            }

            Transform rayPoint = unit.GetComponent<GameObjectComponent>().GameObject.Get<GameObject>("RayPoint").transform;
            if (rayPoint == null)
            {
                return;
            }

            int count = Physics.RaycastNonAlloc(rayPoint.position, Vector3.down, self.Results, self.MaxDistance, self.LayerMask);
            if (count < 1)
            {
                return;
            }

            self.Height = self.Results[0].point.y;

            EventSystem.Instance.Publish(self.Root(), new HeightSync() { Unit = self.GetParent<Unit>(), Height = self.Height });
        }
    }
}