using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (CharacterControllComponent))]
    [EntitySystemOf(typeof (CharacterControllComponent))]
    public static partial class CharacterControllComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CharacterControllComponent self)
        {
            self.CharacterController = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.GetComponent<CharacterController>();
        }
    }
}