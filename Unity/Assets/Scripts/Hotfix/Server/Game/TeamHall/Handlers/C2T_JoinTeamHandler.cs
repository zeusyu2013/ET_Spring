namespace ET.Server
{
    [MessageHandler(SceneType.TeamHall)]
    public class C2T_JoinTeamHandler : MessageHandler<Scene, C2T_JoinTeam, T2C_JoinTeam>
    {
        protected override async ETTask Run(Scene scene, C2T_JoinTeam request, T2C_JoinTeam response)
        {
            int error = scene.GetComponent<TeamHallComponent>().JoinTeam(request.TeamId, request.UnitId);

            response.Error = error;
            response.Message = "";

            await ETTask.CompletedTask;
        }
    }
}