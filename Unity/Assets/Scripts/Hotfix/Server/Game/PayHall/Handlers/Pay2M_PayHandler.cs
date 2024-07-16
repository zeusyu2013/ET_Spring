namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Pay2M_PayHandler : MessageHandler<Scene, Pay2M_Pay>
    {
        protected override async ETTask Run(Scene scene, Pay2M_Pay message)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return;
            }

            Unit unit = unitComponent.Get(message.UnitId);
            if (unit == null)
            {
                return;
            }

            PayComponent payComponent = unit.GetComponent<PayComponent>();
            if (payComponent == null)
            {
                return;
            }
            
            payComponent.Pay(message.ProductId);
            
            await ETTask.CompletedTask;
        }
    }
}