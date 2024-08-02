using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(HeightSyncComponent))]
    [FriendOfAttribute(typeof(ET.Client.HeightSyncComponent))]
    public static partial class HeightSyncComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.HeightSyncComponent self)
        {
            self.RayPoint = self.GetParent<Unit>().GetComponent<GameObjectComponent>().RayPoint;
            self.MaxDistance = 100f;
            self.LayerMask = LayerMask.NameToLayer("Ground");
        }

        [EntitySystem]
        private static void Update(this ET.Client.HeightSyncComponent self)
        {
            RaycastHit[] result = {};
            int count = Physics.RaycastNonAlloc(self.RayPoint.position, Vector3.down, result, self.MaxDistance, self.LayerMask);
            if (count < 1)
            {
                return;
            }

            self.Height = result[0].point.y;
        }
    }
}