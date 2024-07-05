namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_DeleteFriendHandler : MessageLocationHandler<Unit, C2M_DeleteFriend, M2C_DeleteFriend>
    {
        protected override async ETTask Run(Unit unit, C2M_DeleteFriend request, M2C_DeleteFriend response)
        {
            unit.GetComponent<FriendComponent>().DeleteFriend(request.UnitId);

            await ETTask.CompletedTask;
        }
    }
}