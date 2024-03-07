using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class CharacterControllerComponent: Entity, IAwake, IUpdate
    {
        public CharacterController CharacterController;
    }
}