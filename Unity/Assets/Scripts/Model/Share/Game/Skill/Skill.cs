namespace ET
{
    [ChildOf(typeof(SkillComponent))]
    public class Skill : Entity, IAwake<int, int>, IDestroy
    {
        public int ConfigId;

        public int Level;

        public SkillConfig SkillConfig => SkillConfigCategory.Instance.Get(this.ConfigId, this.Level);
    }
}