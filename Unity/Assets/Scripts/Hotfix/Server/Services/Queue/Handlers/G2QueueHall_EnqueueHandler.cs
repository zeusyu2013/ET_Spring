namespace ET.Server
{
    [MessageHandler(SceneType.QueueHall)]
    public class G2QueueHall_EnqueueHandler : MessageHandler<Scene, G2QueueHall_Enqueue, QueueHall2G_Enqueue>
    {
        protected override async ETTask Run(Scene scene, G2QueueHall_Enqueue request, QueueHall2G_Enqueue response)
        {
            scene.GetComponent<QueueComponent>();
            
            await ETTask.CompletedTask;
        }
    }
}