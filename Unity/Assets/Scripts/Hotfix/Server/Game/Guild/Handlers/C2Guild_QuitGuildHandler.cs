namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class C2Guild_QuitGuildHandler : MessageHandler<Scene, C2Guild_QuitGuild, Guild2C_QuitGuild>
    {
        protected override async ETTask Run(Scene scene, C2Guild_QuitGuild request, Guild2C_QuitGuild response)
        {
            bool hasGuild = scene.GetComponent<GuildComponent>().IsPlayerInGuild(request.UnitId);
            if (!hasGuild)
            {
                return;
            }

            await ETTask.CompletedTask;
        }
    }
}