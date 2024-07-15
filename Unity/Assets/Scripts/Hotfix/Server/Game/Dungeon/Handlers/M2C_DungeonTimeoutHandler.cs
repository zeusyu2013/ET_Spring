namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2C_DungeonTimeoutHandler : MessageHandler<Unit, M2C_DungeonTimeout>
    {
        protected override async ETTask Run(Unit unit, M2C_DungeonTimeout message)
        {
            
            
            await ETTask.CompletedTask;
        }
    }
}