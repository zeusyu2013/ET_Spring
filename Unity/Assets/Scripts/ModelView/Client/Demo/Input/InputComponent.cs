﻿using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class InputComponent: Entity, IAwake, IUpdate
    {
        public float3 MoveDirection;
        
        public List<KeyCode> KeyCodes = new();
    }
}