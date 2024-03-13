namespace ET.Server
{
    [Event(SceneType.Map)]
    public class GameTaskInteractiveCompleted : AEvent<Scene, InteractiveCompleted>
    {
        protected override async ETTask Run(Scene scene, InteractiveCompleted args)
        {
            Unit unit = args.Unit;

            unit.GetComponent<GameTaskComponent>().UpdateTaskSchdule(SubTaskType.SubTaskType_Interactive, args.ConfigId);

            await ETTask.CompletedTask;
        }
    }
}