using System.Collections.Generic;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_Single)]
    public class SelectTargetSingle : ASelectTargetHandler
    {
        public override int Check(SelectTargetComponent selectTargetComponent, CastConfig castConfig, ref List<long> targets)
        {
            if (castConfig.SelectTargetType != SelectTargetType.SelectTargetType_Single)
            {
                return ErrorCode.ERR_CastTargetTypeNotMatch;
            }
            
            Unit unit = selectTargetComponent.GetParent<Unit>();
            if (unit == null || unit.IsDisposed)
            {
                return ErrorCode.ERR_CastIsNull;
            }
            
            targets.Add(unit.Id);

            return ErrorCode.ERR_Success;
        }
    }
}