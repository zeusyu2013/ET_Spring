using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AchievementComponent : Entity, IAwake, IDeserialize, ISerializeToEntity
    {
        public Dictionary<int, EntityRef<Achievement>> Achievements = new();
    }
}