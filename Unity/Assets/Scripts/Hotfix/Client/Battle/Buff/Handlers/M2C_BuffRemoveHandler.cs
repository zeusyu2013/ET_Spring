namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_BuffRemoveHandler : MessageHandler<Scene, M2C_BuffRemove>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffRemove message)
        {
            Log.Console($"玩家{message.UnitId} 移除了BUFF({message.BuffId})");

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

            ClientBuff clientBuff = clientBuffComponent.Get(message.BuffId);
            if (clientBuff == null)
            {
                return;
            }

            EventSystem.Instance.Publish(scene, new BuffRemove()
            {
                Unit = unit,
                BuffId = message.BuffId
            });

            clientBuffComponent.Remove(message.BuffId);

            await ETTask.CompletedTask;
        }
    }
}