using System.Collections.Generic;

namespace ET.Server
{
    [UnitCacheEvent(typeof(AchievementComponent))]
    [ComponentOf(typeof(Unit))]
    public class AchievementComponent : Entity, IAwake, ITransfer, IDeserialize
    {
        public List<int> Achievements = new();
    }
}