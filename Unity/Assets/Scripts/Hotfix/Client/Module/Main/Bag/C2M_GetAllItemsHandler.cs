namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class C2M_GetAllItemsHandler : MessageHandler<Scene, M2C_GetAllItems>
    {
        protected override async ETTask Run(Scene scene, M2C_GetAllItems message)
        {
            
            EventSystem.Instance.Publish(scene, new GetAllItems{ message = message});
            await ETTask.CompletedTask;
        }
    }
}

