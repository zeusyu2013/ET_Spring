using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class InputComponent: Entity, IAwake, IUpdate
    {
        public List<KeyCode> KeyCodes = new();
    }
}