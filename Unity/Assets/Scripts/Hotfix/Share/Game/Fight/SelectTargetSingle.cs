namespace ET
{
    public class SelectTargetSingle : ASelectTargetHandler
    {
        public override int Check(SelectTargetComponent selectTargetComponent, SkillConfig skillConfig)
        {
            if (skillConfig.SkillRange != SkillRange.SkillRange_Single)
            {
                return SelectTargetErrorCode.ERR_SkillRangeNotMatch;
            }

            return SelectTargetErrorCode.ERR_Success;
        }
    }
}