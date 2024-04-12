namespace ET
{
    public class SelectTargetAttribute : BaseAttribute
    {
    }

    [SelectTarget]
    public abstract class ASelectTargetHandler : HandlerObject
    {
        public abstract int Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig);
    }
}