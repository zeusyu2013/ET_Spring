using System.Collections.Generic;
using UnityEngine;
using Animancer;

namespace ET.Client
{
	[ComponentOf]
	public class AnimatorComponent : Entity, IAwake, IUpdate, IDestroy
	{
		public Dictionary<string, AnimationClip> AnimancerStates = new();

		public bool isStop;
		public float stopSpeed;

		public bool isGrounded;
		
		public Animator Animator;
		public AnimancerComponent Animancer;
	}
}