using System.Collections.Generic;
using PathologicalGames;

namespace ET.Client
{
    [ComponentOf]
    public class PoolComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<string, SpawnPool> Pools = new();
    }
}