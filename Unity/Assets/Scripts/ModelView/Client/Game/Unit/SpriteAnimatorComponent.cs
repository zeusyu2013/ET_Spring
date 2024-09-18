using Animancer;
using UnityEngine;

namespace ET.Client
{
    public class SpriteAnimatorComponent : Entity, IAwake, IDestroy
    {
        public Animator Animator;

        public AnimancerComponent Animancer;

        public DirectionalAnimationSet8 DirectionalAnimationSet8;

        public DirectionalAnimationSet CurrentAnimationSet;

        public Vector2 Facing;

        public TimeSynchronizationGroup MovementSynchronization;
    }
}