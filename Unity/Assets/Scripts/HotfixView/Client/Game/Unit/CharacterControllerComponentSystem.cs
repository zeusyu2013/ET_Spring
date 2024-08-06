using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(CharacterControllerComponent))]
    [EntitySystemOf(typeof(CharacterControllerComponent))]
    public static partial class CharacterControllerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CharacterControllerComponent self)
        {
            self.CharacterController = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.GetComponent<CharacterController>();
        }
        
        [EntitySystem]
        private static void Update(this ET.Client.CharacterControllerComponent self)
        {

        }

        public static void MoveForward(this CharacterControllerComponent self)
        {
            Vector3 forward = self.GetParent<Unit>().Forward;
            float speed = self.GetParent<Unit>().GetFloat(GamePropertyType.GP_Speed);
        }
    }
}