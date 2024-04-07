namespace ET.Server
{
    [ChildOf(typeof(FightScoreRankComponent))]
    public class FightScoreRankEntity : Entity, IAwake
    {
        public long UnitId;
        public long FightScore;
    }
}