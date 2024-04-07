using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf]
    public class FightScoreRankComponent : Entity, IAwake, IDestroy, IDeserialize
    {
        public long FightScoreRankSortTimer;
        public long FightScoreRankCacheTime;

        public Dictionary<long, long> CachePlayers = new();
        public SortedList<long, long> Players = new();
    }
}