namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class C2Guild_GetGuildMemberInfosHandler : MessageLocationHandler<Unit, C2Guild_GetGuildMemberInfos, Guild2C_GetGuildMemberInfos>
    {
        protected override async ETTask Run(Unit unit, C2Guild_GetGuildMemberInfos request, Guild2C_GetGuildMemberInfos response)
        {
            await ETTask.CompletedTask;
        }
    }
}