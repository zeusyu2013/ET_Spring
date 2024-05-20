namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class M2G_GetAllGuildsHandler : MessageHandler<Scene, M2G_GetAllGuilds, G2M_GetAllGuilds>
    {
        protected override async ETTask Run(Scene scene, M2G_GetAllGuilds request, G2M_GetAllGuilds response)
        {
            GuildComponent guildComponent = scene.GetComponent<GuildComponent>();
            if (guildComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "没找到工会组件";
                
                return;
            }

            response.GuildInfos = guildComponent.GetAllGuilds();
            
            await ETTask.CompletedTask;
        }
    }
}