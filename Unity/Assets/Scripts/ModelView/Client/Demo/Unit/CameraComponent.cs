using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class CameraComponent: Entity, IAwake, ILateUpdate
    {
        public Transform CameraTransform;
        public Transform LookAt;

        public float Distance = 20.0f;
        public float MaxDistance = 30.0f;
        public float ScrollFactor = 8.0f;
        public float RotateFactor = 5.0f;

        public float HorizontalAngle = 45.0f;
        public float VerticalAngle = 45.0f;
    }
}