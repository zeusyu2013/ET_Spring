using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class CameraComponent: Entity, IAwake, IUpdate, IDestroy
    {
        public Camera MainCamera;

        public CinemachineBrain CinemachineBrain;

        public CinemachineVirtualCamera CinemachineVirtualCamera;

        public CinemachineFramingTransposer CinemachineFramingTransposer;

        public float CameraDistance;

        public float CameraMinDistance;
        public float CameraMaxDistance;

        public float CinemachineTargetYaw;

        public float CinemachineTargetPitch;

        public bool IsEnableRotate = false;
    }
}