using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent : Entity, IAwake, IDestroy
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

                if (value != null)
                {
                    this.Transform = value.transform;
                }
            }
        }

        public Transform Transform { get; private set; }

        public Transform CameraLookAt { get; private set; }

        public Transform RayPoint { get; private set; }
    }
}