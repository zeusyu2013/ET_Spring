namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class M2G_RequestJoinGuildHandler : MessageHandler<Scene, M2G_RequestJoinGuild, G2M_RequestJoinGuild>
    {
        protected override async ETTask Run(Scene scene, M2G_RequestJoinGuild request, G2M_RequestJoinGuild response)
        {
            GuildComponent guildComponent = scene.GetComponent<GuildComponent>();
            if (guildComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "没找到工会组件";
                
                return;
            }

            response.Error = guildComponent.JoinGuild(request.GuildName, request.UnitId);
            
            await ETTask.CompletedTask;
        }
    }
}