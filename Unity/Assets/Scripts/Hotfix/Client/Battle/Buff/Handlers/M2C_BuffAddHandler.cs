namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_BuffAddHandler : MessageHandler<Scene, M2C_BuffAdd>
    {
        protected override async ETTask Run(Scene scene, M2C_BuffAdd message)
        {
            Log.Console($"玩家{message.UnitId} 添加了 {message.BuffInfo.ConfigId} BUFF({message.BuffInfo.Id})");

            Unit unit = scene.GetUnit(message.UnitId);
            if (unit == null)
            {
                return;
            }

            ClientBuff clientBuff = BuffFactory.Create(unit, message.BuffInfo);

            unit.GetComponent<ClientBuffComponent>().Add(clientBuff);
            
            EventSystem.Instance.Publish(scene, new BuffAdd()
            {
                Unit = unit,
                BuffId = message.BuffInfo.Id,
                BuffConfigId = message.BuffInfo.ConfigId
            });

            await ETTask.CompletedTask;
        }
    }
}