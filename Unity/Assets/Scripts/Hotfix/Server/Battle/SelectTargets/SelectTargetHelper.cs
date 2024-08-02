using System.Collections.Generic;

namespace ET.Server
{
    public static class SelectTargetHelper
    {
        public static int Select(Unit caster, SelectTargetType type, SelectTargetsParams selectTargetsParams, ref List<long> targets)
        {
            if (caster == null || caster.IsDisposed)
            {
                return ErrorCode.ERR_CasterIsNull;
            }

            ASelectTargetHandler handler = SelectTargetDispatcherComponent.Instance.Get(type);
            if (handler == null)
            {
                return ErrorCode.ERR_NotFoundSkillSelectHandler;
            }

            int errorCode = handler.Check(caster, selectTargetsParams, ref targets);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return errorCode;
            }

            return ErrorCode.ERR_Success;
        }
    }
}