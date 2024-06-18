namespace ET.Server
{
    [MessageHandler(SceneType.TeamHall)]
    public class C2T_GetTeamsHandler : MessageHandler<Scene, C2T_GetTeams, T2C_GetTeams>
    {
        protected override async ETTask Run(Scene scene, C2T_GetTeams request, T2C_GetTeams response)
        {
            response.Error = ErrorCode.ERR_Success;
            response.TeamInfos = scene.GetComponent<TeamHallComponent>().GetTeams();

            await ETTask.CompletedTask;
        }
    }
}