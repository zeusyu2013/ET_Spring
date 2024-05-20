namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class M2G_CreateGuildHandler : MessageHandler<Scene, M2G_CreateGuild, G2M_CreateGuild>
    {
        protected override async ETTask Run(Scene scene, M2G_CreateGuild request, G2M_CreateGuild response)
        {
            GuildComponent guildComponent = scene.GetComponent<GuildComponent>();
            if (guildComponent == null)
            {
                return;
            }
            
            response.Error = guildComponent.CreateGuild(request.GuildName, request.UnitId);
            
            await ETTask.CompletedTask;
        }
    }
}