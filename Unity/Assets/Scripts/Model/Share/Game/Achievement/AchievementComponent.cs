using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AchievementComponent : Entity, IAwake, IDeserialize, ITransfer
    {
        public List<int> Achievements = new();
    }
}