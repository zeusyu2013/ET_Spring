namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_BuffUpdateHandler : MessageHandler<Scene, M2C_BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffUpdate message)
        {
            Log.Console($"玩家{message.UnitId} 更新 {message.BuffInfo.ConfigId} BUFF({message.BuffInfo.Id})");

            Unit unit = scene.CurrentScene().GetUnit(message.UnitId);
            if (unit == null)
            {
                return;
            }

            ClientBuffComponent clientBuffComponent = unit.GetComponent<ClientBuffComponent>();
            if (clientBuffComponent == null)
            {
                return;
            }

            ClientBuff clientBuff = clientBuffComponent.Get(message.BuffInfo.Id);
            if (clientBuff == null)
            {
                return;
            }

            EventSystem.Instance.Publish(scene, new BuffUpdate()
            {
                Unit = unit,
                BuffId = message.BuffInfo.Id,
                BuffConfigId = message.BuffInfo.ConfigId
            });

            clientBuffComponent.Update(message.BuffInfo);

            await ETTask.CompletedTask;
        }
    }
}