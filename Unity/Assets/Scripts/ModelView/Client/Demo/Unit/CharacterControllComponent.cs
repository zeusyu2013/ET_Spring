using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class CharacterControllComponent: Entity, IAwake
    {
        public CharacterController CharacterController;
    }
}