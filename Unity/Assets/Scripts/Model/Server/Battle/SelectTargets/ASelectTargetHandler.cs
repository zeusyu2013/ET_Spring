using System.Collections.Generic;

namespace ET
{
    public class SelectTargetAttribute : BaseAttribute
    {
        public SelectTargetType Type;

        public SelectTargetAttribute(SelectTargetType type)
        {
            this.Type = type;
        }
    }

    public abstract class ASelectTargetHandler : HandlerObject
    {
        public abstract int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets);
    }
}