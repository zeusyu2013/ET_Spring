using System.Collections.Generic;

namespace ET
{
    public class SelectTargetAttribute : BaseAttribute
    {
    }

    [SelectTarget]
    public abstract class ASelectTargetHandler : HandlerObject
    {
        public abstract int Check(SelectTargetComponent selectTargetComponent, CastConfig castConfig, ref List<long> targets);
    }
}