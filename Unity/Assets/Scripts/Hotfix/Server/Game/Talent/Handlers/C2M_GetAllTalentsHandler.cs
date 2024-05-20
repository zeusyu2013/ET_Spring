namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetAllTalentsHandler : MessageLocationHandler<Unit, C2M_GetAllTalents, M2C_GetAllTalents>
    {
        protected override async ETTask Run(Unit unit, C2M_GetAllTalents request, M2C_GetAllTalents response)
        {
            TalentComponent talentComponent = unit.GetComponent<TalentComponent>();
            if (talentComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "没找到天赋组件";
                return;
            }

            response.TalentInfos = talentComponent.GetTalents();

            await ETTask.CompletedTask;
        }
    }
}