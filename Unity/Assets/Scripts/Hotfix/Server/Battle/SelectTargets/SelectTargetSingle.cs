using System.Collections.Generic;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_Single)]
    public class SelectTargetSingle : ASelectTargetHandler
    {
        public override int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            if (caster == null || caster.IsDisposed)
            {
                return ErrorCode.ERR_CastIsNull;
            }
            
            targets.Add(caster.Id);

            return ErrorCode.ERR_Success;
        }
    }
}