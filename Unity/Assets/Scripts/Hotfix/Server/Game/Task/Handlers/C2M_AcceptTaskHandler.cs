namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AcceptTaskHandler : MessageLocationHandler<Unit, C2M_AcceptTask, M2C_AcceptTask>
    {
        protected override async ETTask Run(Unit unit, C2M_AcceptTask request, M2C_AcceptTask response)
        {
            response.Error = unit.GetComponent<GameTaskComponent>().AcceptTask(request.TaskId);

            await ETTask.CompletedTask;
        }
    }
}