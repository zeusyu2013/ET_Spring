using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AchievementComponent : Entity, IAwake, IDeserialize
    {
        public List<int> Achievements = new();
    }
}