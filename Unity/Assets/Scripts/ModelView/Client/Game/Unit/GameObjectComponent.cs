using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent: Entity, IAwake, IDestroy
    {
        private GameObject gameObject;

        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
            set
            {
                this.gameObject = value;
                this.Transform = value.transform;
                this.CameraLookAt = value.transform.Find("CameraLookAt");
                this.RayPoint = value.transform.Find("RayPoint");
            }
        }

        public Transform Transform { get; private set; }
        
        public Transform CameraLookAt { get; private set; }
        
        public Transform RayPoint { get; private set; }
    }
}