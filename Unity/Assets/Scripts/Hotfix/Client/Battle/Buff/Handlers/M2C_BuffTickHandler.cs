namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_BuffTickHandler : MessageHandler<Scene, M2C_BuffTick>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffTick message)
        {
            Log.Console($"玩家{message.UnitId} 的BUFF({message.BuffId}) 触发Tick");

            Unit unit = scene.GetComponent<UnitComponent>().Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            ClientBuffComponent clientBuffComponent = unit.GetComponent<ClientBuffComponent>();
            if (clientBuffComponent == null)
            {
                return;
            }

            ClientBuff clientBuff = clientBuffComponent.Get(message.BuffId);
            if (clientBuff == null)
            {
                return;
            }
            
            EventSystem.Instance.Publish(scene, new BuffTick(){});
            
            await ETTask.CompletedTask;
        }
    }
}