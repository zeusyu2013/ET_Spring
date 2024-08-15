namespace ET.Server
{
    [MessageHandler(SceneType.TeamHall)]
    public class M2T_GetTeamInfoHandler : MessageHandler<Scene, M2T_GetTeamInfo, T2M_GetTeamInfo>
    {
        protected override async ETTask Run(Scene scene, M2T_GetTeamInfo request, T2M_GetTeamInfo response)
        {
            response.TeamInfo = scene.GetComponent<TeamHallComponent>().GetTeam(request.TeamId);
            
            await ETTask.CompletedTask;
        }
    }
}