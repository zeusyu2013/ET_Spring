using System.Collections.Generic;

namespace ET.Server
{
    public enum SkillStatusType
    {
        Uninitialize,
        Initialized,
        Running,
        Finish,
    }
    
    [ComponentOf(typeof(Unit))]
    public class SkillStatusComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public long CurrentSkillCastInstanceId = default;

        public long CurrentSkillCastId = default;

        public long CurrentSkillStartTime = default;

        public SkillStatusType CurrentSkillStatusType = SkillStatusType.Uninitialize;

        public Dictionary<int, long> Cooldowns = new();
    }
}