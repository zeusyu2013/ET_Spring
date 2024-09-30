namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_EnterBattleHandler : MessageHandler<Scene, M2C_EnterBattle>
    {
        protected override async ETTask Run(Scene scene, M2C_EnterBattle message)
        {
            int sceneConfigId = message.SceneConfigId;
            if (sceneConfigId < 1)
            {
                return;
            }
            
            // 打开对战场景
            
            await ETTask.CompletedTask;
        }
    }
}