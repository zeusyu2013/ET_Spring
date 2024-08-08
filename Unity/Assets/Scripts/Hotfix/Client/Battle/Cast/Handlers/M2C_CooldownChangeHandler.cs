namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_CooldownChangeHandler : MessageHandler<Scene, M2C_CooldownChange>
    {
        protected override async ETTask Run(Scene entity, M2C_CooldownChange message)
        {
            await ETTask.CompletedTask;
        }
    }
}