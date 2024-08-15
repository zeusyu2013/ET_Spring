using System.Collections.Generic;

namespace ET.Server
{
    public class QueueInfo : Entity, IAwake, IDestroy
    {
        public long UnitId;

        public long GateActorId;

        public string Account;

        public int Index;
    }

    public struct ProtectInfo
    {
        public long UnitId;

        public long Time;
    }

    [ComponentOf(typeof(Scene))]
    public class QueueComponent : Entity, IAwake, IDestroy
    {
        public HashSet<long> Online = new();
    }
}