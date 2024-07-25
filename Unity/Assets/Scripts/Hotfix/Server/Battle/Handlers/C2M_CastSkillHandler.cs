namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_CastSkillHandler : MessageLocationHandler<Unit, C2M_CastSkill, M2C_CastSkill>
    {
        protected override async ETTask Run(Unit unit, C2M_CastSkill request, M2C_CastSkill response)
        {
            unit.GetComponent<SkillComponent>().Cast(request.SkillConfigId, request.SkillLevel);

            await ETTask.CompletedTask;
        }
    }
}