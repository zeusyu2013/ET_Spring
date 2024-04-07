namespace ET.Server
{
    [MessageHandler(SceneType.Guild)]
    public class C2Guild_GetGuildMemberInfosHandler : MessageHandler<Scene, C2Guild_GetGuildMemberInfos, Guild2C_GetGuildMemberInfos>
    {
        protected override async ETTask Run(Scene unit, C2Guild_GetGuildMemberInfos request, Guild2C_GetGuildMemberInfos response)
        {
            await ETTask.CompletedTask;
        }
    }
}