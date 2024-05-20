namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class M2G_RequestQuitGuildHandler : MessageHandler<Scene, M2G_RequestQuitGuild, G2M_RequestQuitGuild>
    {
        protected override async ETTask Run(Scene scene, M2G_RequestQuitGuild request, G2M_RequestQuitGuild response)
        {
            GuildComponent guildComponent = scene.GetComponent<GuildComponent>();
            if (guildComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "没找到工会组件";
                
                return;
            }

            response.Error = guildComponent.QuitGuild(request.GuildName, request.UnitId);
            
            await ETTask.CompletedTask;
        }
    }
}