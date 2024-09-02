﻿using System.Collections.Generic;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_SelectSingle)]
    public class SelectTargetSingle : ASelectTargetHandler
    {
        public override int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            if (caster == null || caster.IsDisposed)
            {
                return ErrorCode.ERR_CastIsNull;
            }

            Single param = selectTargetsParams as Single;
            
            if (targets.Count < 1 && param.IncludeSelf)
            {
                targets.Add(caster.Id);
            }

            return ErrorCode.ERR_Success;
        }
    }
}