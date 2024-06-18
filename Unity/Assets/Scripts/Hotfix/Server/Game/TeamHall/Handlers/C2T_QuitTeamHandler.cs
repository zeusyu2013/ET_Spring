namespace ET.Server
{
    [MessageHandler(SceneType.TeamHall)]
    public class C2T_QuitTeamHandler : MessageHandler<Scene, C2T_QuitTeam, T2C_QuitTeam>
    {
        protected override async ETTask Run(Scene scene, C2T_QuitTeam request, T2C_QuitTeam response)
        {
            int error = scene.GetComponent<TeamHallComponent>().QuitTeam(request.TeamId, request.UnitId);

            response.Error = error;
            response.Message = "";
            
            await ETTask.CompletedTask;
        }
    }
}