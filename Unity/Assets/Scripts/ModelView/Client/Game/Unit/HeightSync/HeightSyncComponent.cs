using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class HeightSyncComponent: Entity, IAwake, IDestroy
    {
        public float MaxDistance;

        public int LayerMask;

        public RaycastHit[] Results;

        public float Height;

        public long Timer;
    }
}