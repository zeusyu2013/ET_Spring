namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class SkillStatusComponent : Entity, IAwake, IDestroy
    {
        public long CurrentSkillCastInstanceId = default;

        public long CurrentSkillCastId = default;

        public long CurrentSkillStartTime = default;
    }
}