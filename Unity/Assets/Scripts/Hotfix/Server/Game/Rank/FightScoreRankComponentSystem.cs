using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(FightScoreRankComponent))]
    [FriendOf(typeof(FightScoreRankComponent))]
    [FriendOf(typeof(FightScoreRankEntity))]
    public static partial class FightScoreRankComponentSystem
    {
        [Invoke(TimerInvokeType.FightScoreRankSortTimer)]
        public class FightScoreRankSortTimer : ATimer<FightScoreRankComponent>
        {
            protected override void Run(FightScoreRankComponent self)
            {
                self.SortRank().Coroutine();
            }
        }

        [EntitySystem]
        private static void Awake(this FightScoreRankComponent self)
        {
            self.FightScoreRankSortTimer = self.Root().GetComponent<TimerComponent>()
                    .NewRepeatedTimer(5 * 60 * 1000, TimerInvokeType.FightScoreRankSortTimer, self);
        }

        public static void AddPlayer(this FightScoreRankComponent self, long unitId, long fightScore)
        {
            if (!self.CachePlayers.ContainsKey(unitId))
            {
                self.CachePlayers.Add(unitId, 0);
            }

            long score = self.CachePlayers[unitId];
            if (score >= fightScore)
            {
                return;
            }

            self.CachePlayers[unitId] = fightScore;
        }

        public static SortedList<long, long> GetRanks(this FightScoreRankComponent self)
        {
            return self.Players;
        }

        private static async ETTask SortRank(this FightScoreRankComponent self)
        {
            if (self.CachePlayers.Count < 1)
            {
                return;
            }

            self.FightScoreRankCacheTime = TimeInfo.Instance.ServerNow();

            foreach ((long id, long score) in self.CachePlayers)
            {
                self.Players[id] = score;
            }

            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, self.FightScoreRankCacheTime))
            {
                List<Entity> entities = new();
                foreach (var player in self.Players)
                {
                    //entities.Add(player);
                }

                await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).InsertBatch(entities);
            }
        }

        [EntitySystem]
        private static void Destroy(this FightScoreRankComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.FightScoreRankSortTimer);
        }

        [EntitySystem]
        private static void Deserialize(this FightScoreRankComponent self)
        {
            foreach (Entity childrenValue in self.Children.Values)
            {
            }
        }
    }
}