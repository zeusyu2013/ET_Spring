using System.Collections.Generic;
using PathologicalGames;

namespace ET.Client
{
    public class PoolComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<string, SpawnPool> Pools = new();
    }
}