using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class FxComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<string, Dictionary<Transform, long>> Fxes = new();

        public Dictionary<string, Dictionary<Transform, long>> AddFxes = new();
        
        public Dictionary<string, List<Transform>> RemoveFxes = new();

        public long Timer;
    }
}