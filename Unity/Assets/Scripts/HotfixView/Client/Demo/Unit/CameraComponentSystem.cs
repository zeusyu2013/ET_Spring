using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(CameraComponent))]
    [EntitySystemOf(typeof (CameraComponent))]
    public static partial class CameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CameraComponent self)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Log.Error("camera component: main camera is null");
                return;
            }

            self.CameraTransform = mainCamera.transform;
            self.LookAt = self.GetParent<Unit>().GetComponent<GameObjectComponent>().CameraLookAt;
        }

        [EntitySystem]
        private static void LateUpdate(this CameraComponent self)
        {
            if (self.CameraTransform == null || self.LookAt == null)
            {
                return;
            }

            // 滚轮
            float scrollAmount = Input.GetAxis("Mouse ScrollWheel");
            self.Distance -= scrollAmount * self.ScrollFactor;

            // 限制相机距离
            self.Distance = Mathf.Clamp(self.Distance, 0, self.MaxDistance);

            bool isMouseLeftDown = Input.GetMouseButton(0);
            bool isMouseRightDown = Input.GetMouseButton(1);
            if (isMouseLeftDown || isMouseRightDown)
            {
                float axisX = Input.GetAxis("Mouse X");
                float axisY = Input.GetAxis("Mouse Y");

                self.HorizontalAngle += axisX * self.RotateFactor;
                self.VerticalAngle += axisY * self.RotateFactor;
                self.VerticalAngle = Mathf.Clamp(self.VerticalAngle, -80, 0);
                if (isMouseRightDown)
                {
                    // 按住右键旋转相机时带动角色旋转
                    self.GetParent<Unit>().Rotation = Quaternion.Euler(0, self.HorizontalAngle, 0);
                }
            }

            Quaternion rotation = Quaternion.Euler(-self.VerticalAngle, self.HorizontalAngle, 0);
            Vector3 offset = rotation * Vector3.back * self.Distance;
            self.CameraTransform.position = self.LookAt.position + offset;
            self.CameraTransform.rotation = rotation;
        }
    }
}