using Cinemachine;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (CameraComponent))]
    [EntitySystemOf(typeof (CameraComponent))]
    public static partial class CameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CameraComponent self)
        {
            self.MainCamera = Camera.main;
            self.CameraMinDistance = 5;
            self.CameraMaxDistance = 20;

            self.CinemachineBrain = self.MainCamera.gameObject.AddOrGetComponent<CinemachineBrain>();
            self.CinemachineVirtualCamera = self.MainCamera.gameObject.AddOrGetComponent<CinemachineVirtualCamera>();
            self.CinemachineFramingTransposer = self.CinemachineVirtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>();
            self.CinemachineFramingTransposer.m_XDamping =
                    self.CinemachineFramingTransposer.m_YDamping = self.CinemachineFramingTransposer.m_ZDamping = 0;

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            // Transposer下只有follow起作用
            self.CinemachineVirtualCamera.Follow = unit.GetComponent<GameObjectComponent>().CameraLookAt;

            self.CameraRotation();
        }

        [EntitySystem]
        private static void Update(this CameraComponent self)
        {
            if (Input.GetMouseButtonDown(1))
            {
                self.IsEnableRotate = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                self.IsEnableRotate = false;
            }

            if (self.IsEnableRotate)
            {
                self.CameraRotation();
            }

            self.CameraScroll();
        }

        private static void CameraRotation(this CameraComponent self)
        {
            float mouseX = Input.GetAxis("Mouse X") * 200;
            float mouseY = Input.GetAxis("Mouse Y") * 200;

            self.CinemachineTargetYaw += mouseX * Time.deltaTime;
            self.CinemachineTargetPitch -= mouseY * Time.deltaTime;

            self.CinemachineTargetYaw = self.ClampAngle(self.CinemachineTargetYaw, float.MinValue, float.MaxValue);
            self.CinemachineTargetPitch = self.ClampAngle(self.CinemachineTargetPitch, 1, 80);

            Quaternion targetRotation = Quaternion.Euler(self.CinemachineTargetPitch, self.CinemachineTargetYaw, 0);
            self.MainCamera.transform.rotation = targetRotation;
            
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            unit.Rotation = Quaternion.Euler(0, self.CinemachineTargetYaw, 0);
        }

        private static void CameraScroll(this CameraComponent self)
        {
            self.CameraDistance -= Input.GetAxis("Mouse ScrollWheel") * 5;
            self.CameraDistance = Mathf.Clamp(self.CameraDistance, self.CameraMinDistance, self.CameraMaxDistance);
            self.CinemachineFramingTransposer.m_CameraDistance =
                    Mathf.Lerp(self.CinemachineFramingTransposer.m_CameraDistance, self.CameraDistance, Time.deltaTime * 10);
        }

        private static float ClampAngle(this CameraComponent self, float angle, float min, float max)
        {
            if (angle < -360)
            {
                angle += 360;
            }

            if (angle > 360)
            {
                angle -= 360;
            }

            return Mathf.Clamp(angle, min, max);
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.CameraComponent self)
        {
            UnityEngine.Object.Destroy(self.CinemachineBrain);
            UnityEngine.Object.Destroy(self.CinemachineVirtualCamera);

            self.MainCamera = null;
        }
    }
}