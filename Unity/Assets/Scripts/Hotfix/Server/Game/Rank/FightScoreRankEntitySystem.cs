namespace ET.Server
{
    [EntitySystemOf(typeof(FightScoreRankEntity))]
    [FriendOfAttribute(typeof(ET.Server.FightScoreRankEntity))]
    public static partial class FightScoreRankEntitySystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.FightScoreRankEntity self)
        {
        }

        public static FightScoreRankEntityInfo ToMessage(this FightScoreRankEntity self)
        {
            FightScoreRankEntityInfo info = FightScoreRankEntityInfo.Create();
            info.UnitId = self.UnitId;
            info.FightScore = self.FightScore;
            return info;
        }
    }
}