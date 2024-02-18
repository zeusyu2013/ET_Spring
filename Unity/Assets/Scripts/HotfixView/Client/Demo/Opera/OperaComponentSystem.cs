using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    [FriendOfAttribute(typeof(ET.Client.InputComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map");
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            // if (Input.GetMouseButtonDown(1))
            // {
            //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //     RaycastHit hit;
            //     if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
            //     {
            //         C2M_PathfindingResult c2MPathfindingResult = C2M_PathfindingResult.Create();
            //         c2MPathfindingResult.Position = hit.point;
            //         self.Root().GetComponent<ClientSenderComponent>().Send(c2MPathfindingResult);
            //     }
            // }

            InputComponent inputComponent = self.Root().GetComponent<InputComponent>();
            if (inputComponent.MoveDirection.x > 0 || inputComponent.MoveDirection.y > 0)
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                float3 nextPoint = new(unit.Position.x + inputComponent.MoveDirection.x, unit.Position.y,
                    unit.Position.z + inputComponent.MoveDirection.y);
                unit.MoveToAsync(new List<float3>(){ nextPoint }).Coroutine();
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