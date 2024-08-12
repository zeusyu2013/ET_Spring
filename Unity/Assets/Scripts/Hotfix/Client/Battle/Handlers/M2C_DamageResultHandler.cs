namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_DamageResultHandler : MessageHandler<Scene, M2C_DamageResult>
    {
        protected override async ETTask Run(Scene entity, M2C_DamageResult message)
        {
            await ETTask.CompletedTask;
        }
    }
}