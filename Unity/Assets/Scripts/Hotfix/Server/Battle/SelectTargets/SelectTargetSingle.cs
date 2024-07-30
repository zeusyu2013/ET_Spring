using System.Collections.Generic;

namespace ET.Server
{
    [SelectTarget]
    public class SelectTargetSingle : ASelectTargetHandler
    {
        public override int Check(SelectTargetComponent selectTargetComponent, CastConfig castConfig, ref List<long> targets)
        {
            if (castConfig.SelectTargetType != SelectTargetType.SelectTargetType_Single)
            {
                return ErrorCode.ERR_CastTargetTypeNotMatch;
            }

            return ErrorCode.ERR_Success;
        }
    }
}