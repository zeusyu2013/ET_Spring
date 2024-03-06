using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    [FriendOfAttribute(typeof(ET.Client.InputComponent))]
    [FriendOfAttribute(typeof(ET.Client.CameraComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map");
            self.InputComponent = self.Root().GetComponent<InputComponent>();
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            InputComponent inputComponent = self.Root().GetComponent<InputComponent>();
            if (inputComponent.MoveDirection.x != 0 || inputComponent.MoveDirection.z != 0)
            {
                Vector3 moveDir = inputComponent.MoveDirection;
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                Quaternion rotation = Quaternion.Euler(0, unit.GetComponent<CameraComponent>().CinemachineTargetYaw, 0);
                Vector3 unitPos = unit.Position;
                unitPos.y = 0;
                Vector3 newPos = unitPos + (rotation * moveDir * 4f);

                using ListComponent<float3> list = ListComponent<float3>.Create();
                list.Add(unit.Position);
                list.Add(newPos);
                unit.MoveToAsync(list).Coroutine();

                C2M_PathfindingResult c2MPathfindingResult = C2M_PathfindingResult.Create();
                c2MPathfindingResult.Position = newPos;
                self.Root().GetComponent<ClientSenderComponent>().Send(c2MPathfindingResult);
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