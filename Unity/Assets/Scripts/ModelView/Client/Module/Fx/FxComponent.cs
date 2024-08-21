using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FxComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<Transform, long> Fxes = new();

        public Dictionary<Transform, long> AddFxes = new();
        
        public List<Transform> RemoveFxes = new();

        public long Timer;
    }
}