using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class HeightSyncComponent: Entity, IAwake, IUpdate
    {
        public Transform RayPoint;

        public float MaxDistance;

        public int LayerMask;

        public float Height;
    }
}