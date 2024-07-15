namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_CreateDungeonHandler : MessageLocationHandler<Unit, C2M_CreateDungeon, M2C_CreateDungeon>
    {
        protected override async ETTask Run(Unit unit, C2M_CreateDungeon request, M2C_CreateDungeon response)
        {
            await ETTask.CompletedTask;
            
            ActorId actorId = unit.Root().GetComponent<DungeonComponent>().EnterDungeon(request.DungeonConfig, unit.Id);
            if (actorId.Equals(new ActorId()))
            {
                response.Error = ErrorCode.ERR_CreateDungeonFailed;
            }

            response.ActorId = actorId;
        }
    }
}