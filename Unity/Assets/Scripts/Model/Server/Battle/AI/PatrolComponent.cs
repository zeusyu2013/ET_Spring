using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [ComponentOf]
    public class PatrolComponent : Entity, IAwake, IDestroy
    {
        public List<float3> Path = new();
        
        public int Index;
        
        public long NextMoveTime;
    }
}