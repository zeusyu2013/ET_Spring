using System.Collections.Generic;

namespace ET
{
    public class SelectTargetAttribute : BaseAttribute
    {
    }

    [SelectTarget]
    public abstract class ASelectTargetHandler : HandlerObject
    {
        public abstract (int, List<Unit>) Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig);
    }
}