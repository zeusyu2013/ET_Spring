namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_BattleResultHandler : MessageHandler<Scene, M2C_BattleResult>
    {
        protected override async ETTask Run(Scene entity, M2C_BattleResult message)
        {
            await ETTask.CompletedTask;
        }
    }
}