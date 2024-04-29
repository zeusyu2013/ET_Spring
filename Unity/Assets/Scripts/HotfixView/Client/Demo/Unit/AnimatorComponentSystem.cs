using System;
using Animancer;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(AnimatorComponent))]
    [FriendOf(typeof(AnimatorComponent))]
    public static partial class AnimatorComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this AnimatorComponent self)
        {
            self.Animator = null;
            self.Animancer = null;
        }

        [EntitySystem]
        private static void Awake(this AnimatorComponent self)
        {
            Animator animator = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.GetComponent<Animator>();

            if (animator == null)
            {
                Log.Warning($"{self.GetParent<Unit>().ConfigId} 缺少Animator组件");
                return;
            }

            self.Animator = animator;

            self.Animancer = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.Get<NamedAnimancerComponent>("Animancer");
        }

        [EntitySystem]
        private static void Update(this AnimatorComponent self)
        {
            if (self.Animancer == null)
            {
                return;
            }
            
            if (self.isStop)
            {
                return;
            }

            try
            {
                self.Animancer.Evaluate();
            }
            catch (Exception ex)
            {
                throw new Exception($"", ex);
            }
        }

        public static async ETTask Play(this AnimatorComponent self, string action, float fade = 0.25f)
        {
            if (string.IsNullOrEmpty(action))
            {
                Log.Warning("播放动画名是空");
                return;
            }

            if (!self.Animancer.States.TryGet(action, out var state))
            {
                AnimationClip clip = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<AnimationClip>($"{action}.anim");
                self.Animancer.States.Create(clip);
            }

            self.Animancer.Play(state, fade);
            state.Events.OnEnd = self.OnEnd;
        }

        private static void OnEnd(this AnimatorComponent self)
        {
            self.Animancer.Play(self.Animancer.States[0]);
        }

        public static void PauseAnimator(this AnimatorComponent self)
        {
            if (self.isStop)
            {
                return;
            }

            self.isStop = true;

            if (self.Animator == null)
            {
                return;
            }

            self.stopSpeed = self.Animancer.States.Current.Speed;
            self.Animancer.States.Current.Speed = 0;
        }

        public static void SetAnimatorSpeed(this AnimatorComponent self, float speed)
        {
            self.stopSpeed = self.Animancer.States.Current.Speed;
            self.Animancer.States.Current.Speed = speed;
        }

        public static void ResetAnimatorSpeed(this AnimatorComponent self)
        {
            self.Animancer.States.Current.Speed = self.stopSpeed;
        }
    }
}