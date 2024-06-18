namespace ET.Server
{
    [MessageHandler(SceneType.TeamHall)]
    public class C2T_CreateTeamHandler : MessageHandler<Scene, C2T_CreateTeam, T2C_CreateTeam>
    {
        protected override async ETTask Run(Scene scene, C2T_CreateTeam request, T2C_CreateTeam response)
        {
            int errorCode = scene.GetComponent<TeamHallComponent>().CreateTeam(request.UnitId, out var teamId);

            response.Error = errorCode;
            response.Message = "";
            response.TeamId = teamId;
            
            await ETTask.CompletedTask;
        }
    }
}