using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class InputComponent: Entity, IAwake, IUpdate
    {
        public float3 PreMoveDirection;
        public float3 MoveDirection;

        public float3 JoystickMoveDirection;
        
        public List<KeyCode> KeyCodes = new();
    }
}