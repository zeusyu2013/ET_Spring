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
            GameObject go = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            Animator animator = go.Get<Animator>("Animator");
            if (animator == null)
            {
                Log.Error($"{self.GetParent<Unit>().ConfigId} 缺少Animator组件");
            }

            self.Animator = animator;

            self.Animancer = go.Get<AnimancerComponent>("AnimancerComponent");
            if (self.Animancer == null)
            {
                Log.Error($"{self.GetParent<Unit>().ConfigId} 缺少AnimancerComponent组件");
            }

            self.Play("idle").Coroutine();
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

            if (!self.AnimancerStates.TryGetValue(action, out var state))
            {
                AnimationClip clip = await self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetAsync<AnimationClip>($"Assets/Bundles/Animations/{action}.anim");
                if (clip == null)
                {
                    Log.Error($"角色【{self.GetParent<Unit>().ConfigId}】动画【{action}】加载失败");
                }
                else
                {
                    self.AnimancerStates.Add(action, clip);
                }
            }

            AnimancerState animancerState = self.Animancer.Play(self.AnimancerStates[action]);

            if (!animancerState.IsLooping)
            {
                animancerState.Events.OnEnd -= self.OnEnd;
                animancerState.Events.OnEnd += self.OnEnd;
            }
        }

        private static void OnEnd(this AnimatorComponent self)
        {
            self.Animancer.Play(self.AnimancerStates["idle"]);
        }

        public static AnimancerState PlayingState(this AnimatorComponent self)
        {
            return self.Animancer.States.Current;
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
            self.Animancer.Playable.PauseGraph();
        }

        public static void SetAnimatorSpeed(this AnimatorComponent self, float speed)
        {
            self.stopSpeed = self.Animancer.States.Current.Speed;
            self.Animancer.States.Current.Speed = speed;
            self.Animancer.Playable.UnpauseGraph();
        }

        public static void ResetAnimatorSpeed(this AnimatorComponent self)
        {
            self.Animancer.States.Current.Speed = self.stopSpeed;
            self.Animancer.Playable.UnpauseGraph();
        }
    }
}