namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_SetPositionHandler : MessageHandler<Scene, M2C_SetPosition>
    {
        protected override async ETTask Run(Scene scene, M2C_SetPosition message)
        {
            UnitComponent unitComponent = scene.CurrentScene().GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return;
            }

            Unit unit = unitComponent.Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            unit.Position = message.Position;
            unit.Rotation = message.Rotation;

            await ETTask.CompletedTask;
        }
    }
}