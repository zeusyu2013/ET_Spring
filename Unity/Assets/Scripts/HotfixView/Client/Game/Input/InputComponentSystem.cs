﻿using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(InputComponent))]
    [EntitySystemOf(typeof(InputComponent))]
    public static partial class InputComponentSystem
    {
        [EntitySystem]
        private static void Awake(this InputComponent self)
        {
            // 注册基础按键，游戏足够用了
            self.KeyCodes.Add(KeyCode.A);
            self.KeyCodes.Add(KeyCode.W);
            self.KeyCodes.Add(KeyCode.S);
            self.KeyCodes.Add(KeyCode.D);
            self.KeyCodes.Add(KeyCode.Space);
            self.KeyCodes.Add(KeyCode.J);
            self.KeyCodes.Add(KeyCode.K);
            self.KeyCodes.Add(KeyCode.C);
            self.KeyCodes.Add(KeyCode.B);
            self.KeyCodes.Add(KeyCode.P);
            self.KeyCodes.Add(KeyCode.R);
            self.KeyCodes.Add(KeyCode.T);
            self.KeyCodes.Add(KeyCode.I);
            self.KeyCodes.Add(KeyCode.O);
            self.KeyCodes.Add(KeyCode.Alpha1);
            self.KeyCodes.Add(KeyCode.Alpha2);
            self.KeyCodes.Add(KeyCode.Alpha3);
            self.KeyCodes.Add(KeyCode.Alpha4);
            self.KeyCodes.Add(KeyCode.Alpha5);
            self.KeyCodes.Add(KeyCode.Alpha6);
            self.KeyCodes.Add(KeyCode.Alpha7);
            self.KeyCodes.Add(KeyCode.Alpha8);
            self.KeyCodes.Add(KeyCode.Alpha9);
            self.KeyCodes.Add(KeyCode.Alpha0);
        }

        [EntitySystem]
        private static void Update(this InputComponent self)
        {
            self.MoveDirection.x = Input.GetAxis("Horizontal");
            self.MoveDirection.y = 0;
            self.MoveDirection.z = Input.GetAxis("Vertical");
            bool3 preZero = self.PreMoveDirection != float3.zero;
            if (math.length(self.MoveDirection) < 0.1f && (preZero.x & preZero.z))
            {
                self.Scene().CurrentScene().GetComponent<OperaComponent>().Stop();
            }

            self.PreMoveDirection = self.MoveDirection;

            foreach (KeyCode keyCode in self.KeyCodes)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    EventSystem.Instance.Publish(self.Root(), new KeyDown() { Unit = self.GetParent<Unit>(), KeyCode = keyCode });
                }
            }
        }
    }
}