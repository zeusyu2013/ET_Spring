using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    [FriendOfAttribute(typeof(ET.Client.InputComponent))]
    [FriendOfAttribute(typeof(ET.Client.CameraComponent))]
    [FriendOfAttribute(typeof(ET.Client.HeightSyncComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.Result = C2M_PathfindingResult.Create();
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            InputComponent inputComponent = self.Root().GetComponent<InputComponent>();
            if (inputComponent.MoveDirection.x != 0 || inputComponent.MoveDirection.z != 0 ||
                inputComponent.JoystickMoveDirection.x != 0 || inputComponent.JoystickMoveDirection.y != 0)
            {
                Vector3 moveDir = inputComponent.JoystickMoveDirection is { x: 0, y: 0 } ? inputComponent.MoveDirection
                        : inputComponent.JoystickMoveDirection;
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                Quaternion rotation = Quaternion.Euler(0, unit.GetComponent<CameraComponent>().CinemachineTargetYaw, 0);

                self.JoyMove(rotation * moveDir.normalized);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                self.Test1().Coroutine();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                self.Test2().Coroutine();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CodeLoader.Instance.Reload();
                return;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                C2M_TransferMap c2MTransferMap = C2M_TransferMap.Create();
                self.Root().GetComponent<ClientSenderComponent>().Call(c2MTransferMap).Coroutine();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ClientCastHelper.CastSkill(self.Scene(), 120001).Coroutine();
            }
        }

        private static void JoyMove(this OperaComponent self, float3 direction)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            float3 unitPosition = unit.Position;
            unitPosition.y = unit.GetComponent<HeightSyncComponent>().Height;
            float3 nextPosition = unitPosition + (direction * 4.0f);

            using (var list = ListComponent<float3>.Create())
            {
                list.Add(unitPosition);
                list.Add(nextPosition);
                unit.MoveToAsync(list).Coroutine();
            }

            self.Result.Position = nextPosition;
            self.Root().GetComponent<ClientSenderComponent>().Send(self.Result);
        }

        public static void Stop(this OperaComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());

            unit.GetComponent<MoveComponent>().StopForce();

            C2M_JoyStop c2MJoyStop = C2M_JoyStop.Create();
            c2MJoyStop.UnitId = unit.Id;
            c2MJoyStop.Position = unit.Position;
            c2MJoyStop.Direction = unit.Forward;
            self.Root().GetComponent<ClientSenderComponent>().Send(c2MJoyStop);
        }

        private static async ETTask Test1(this OperaComponent self)
        {
            Log.Debug($"Croutine 1 start1 ");
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(1, 20000, 3000))
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(6000);
            }

            Log.Debug($"Croutine 1 end1");
        }

        private static async ETTask Test2(this OperaComponent self)
        {
            Log.Debug($"Croutine 2 start2");
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(1, 20000, 3000))
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            }

            Log.Debug($"Croutine 2 end2");
        }
    }
}