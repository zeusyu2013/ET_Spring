﻿using System.Collections.Generic;

namespace ET.Server
{
    [SelectTarget(SelectTargetType.SelectTargetType_SelectCycle)]
    public class SelectTargetSelectCycle : ASelectTargetHandler
    {
        public override int Check(Unit caster, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            SelectCycle cycle = (SelectCycle)selectTargetsParams;
            
            return ErrorCode.ERR_Success;
        }
    }
}