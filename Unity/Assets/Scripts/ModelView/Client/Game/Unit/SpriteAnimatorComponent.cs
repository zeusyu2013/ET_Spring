using Animancer;
using UnityEngine;

namespace ET.Client
{
    public class SpriteAnimatorComponent : Entity, IAwake, IDestroy
    {
        public AnimancerComponent Animancer;

        public DirectionalAnimationSet Idle;
        public DirectionalAnimationSet Walk;
        public DirectionalAnimationSet Run;
        
        public DirectionalAnimationSet CurrentAnimationSet;

        public Vector2 Facing;

        public TimeSynchronizationGroup MovementSynchronization;
    }
}