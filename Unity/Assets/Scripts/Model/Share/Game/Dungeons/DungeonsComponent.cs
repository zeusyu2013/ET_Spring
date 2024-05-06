using System.Collections.Generic;

namespace ET
{
    public class DungeonsComponent : Entity, IAwake, IDeserialize
    {
        public Dictionary<int, int> Dungeons = new();
    }
}