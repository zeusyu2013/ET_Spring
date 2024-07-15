namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class SessionDisconnect_DungeonComponentHandler : MessageLocationHandler<Unit, G2M_SessionDisconnect>
    {
        protected override async ETTask Run(Unit unit, G2M_SessionDisconnect message)
        {
            Scene scene = unit.Root();
            DungeonComponent dungeonComponent = scene.GetComponent<DungeonComponent>();
            if (dungeonComponent == null)
            {
                return;
            }

            dungeonComponent.ExitDungeon(unit.Id);
            
            await ETTask.CompletedTask;
        }
    }
}