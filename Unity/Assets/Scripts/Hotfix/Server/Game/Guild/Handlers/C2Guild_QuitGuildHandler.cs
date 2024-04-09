namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class C2Guild_QuitGuildHandler : MessageLocationHandler<Unit, C2Guild_QuitGuild, Guild2C_QuitGuild>
    {
        protected override async ETTask Run(Unit unit, C2Guild_QuitGuild request, Guild2C_QuitGuild response)
        {
            await ETTask.CompletedTask;
        }
    }
}