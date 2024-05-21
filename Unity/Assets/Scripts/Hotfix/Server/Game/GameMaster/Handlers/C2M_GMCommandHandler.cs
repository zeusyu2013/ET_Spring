namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GMCommandHandler : MessageLocationHandler<Unit, C2M_GMCommand>
    {
        protected override async ETTask Run(Unit unit, C2M_GMCommand message)
        {
            GameMasterComponent gameMasterComponent = unit.Root().GetComponent<GameMasterComponent>();
            if (gameMasterComponent == null)
            {
                return;
            }
            
            string command = message.GmCommand;
            if (string.IsNullOrEmpty(command))
            {
                return;
            }

            gameMasterComponent.Execute(unit, command);

            await ETTask.CompletedTask;
        }
    }
}