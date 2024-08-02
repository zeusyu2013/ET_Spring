namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_NumericChangeHandler : MessageHandler<Scene, M2C_NumericChange>
    {
        protected override async ETTask Run(Scene scene, M2C_NumericChange message)
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
            
            foreach ((int key, long value) in message.KV)
            {
                unit.GetComponent<NumericComponent>().Set(key, value);
            }
            
            await ETTask.CompletedTask;
        }
    }
}