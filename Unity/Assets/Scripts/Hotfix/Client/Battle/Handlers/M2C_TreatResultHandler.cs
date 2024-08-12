namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_TreatResultHandler : MessageHandler<Scene, M2C_TreatResult>
    {
        protected override async ETTask Run(Scene entity, M2C_TreatResult message)
        {
            await ETTask.CompletedTask;
        }
    }
}