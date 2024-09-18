using Animancer;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(SpriteAnimatorComponent))]
    [FriendOfAttribute(typeof(ET.Client.SpriteAnimatorComponent))]
    public static partial class SpriteAnimatorComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.SpriteAnimatorComponent self)
        {
            self.Animator = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.Get<Animator>("Animator");
            self.Animancer = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.Get<AnimancerComponent>("AnimancerComponent");
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.SpriteAnimatorComponent self)
        {
            self.Animator = null;
            self.Animancer = null;
            self.DirectionalAnimationSet8 = null;
            self.CurrentAnimationSet = null;
            self.Facing = Vector2.zero;
            self.MovementSynchronization.Clear();
            self.MovementSynchronization = null;
        }

        public static void SetFacing(this SpriteAnimatorComponent self, Vector2 facing)
        {
            self.Facing = facing;
        }

        public static Vector2 GetFacing(this SpriteAnimatorComponent self)
        {
            return self.Facing;
        }

        public static void Play(this SpriteAnimatorComponent self, DirectionalAnimationSet animations)
        {
            self.MovementSynchronization.StoreTime(self.CurrentAnimationSet);

            self.CurrentAnimationSet = animations;
            self.Animancer.Play(animations.GetClip(self.Facing));

            self.MovementSynchronization.SyncTime(self.CurrentAnimationSet);
        }
    }
}