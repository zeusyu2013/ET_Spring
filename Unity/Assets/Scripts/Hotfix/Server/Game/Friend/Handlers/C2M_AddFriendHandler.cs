namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_AddFriendHandler : MessageLocationHandler<Unit, C2M_AddFriend, M2C_AddFriend>
    {
        protected override async ETTask Run(Unit unit, C2M_AddFriend request, M2C_AddFriend response)
        {
            unit.GetComponent<FriendComponent>().AddFriend(request.UnitId, "");

            await ETTask.CompletedTask;
        }
    }
}