namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_CompleteTaskHandler : MessageLocationHandler<Unit, C2M_CompleteTask, M2C_CompleteTask>
    {
        protected override async ETTask Run(Unit unit, C2M_CompleteTask request, M2C_CompleteTask response)
        {
            response.Error = unit.GetComponent<GameTaskComponent>().CommitTask(request.TaskId);

            await ETTask.CompletedTask;
        }
    }
}