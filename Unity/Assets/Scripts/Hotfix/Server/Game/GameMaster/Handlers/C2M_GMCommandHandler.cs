namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GMCommandHandler : MessageLocationHandler<Unit, C2M_GMCommand>
    {
        protected override async ETTask Run(Unit unit, C2M_GMCommand message)
        {
            string command = message.GmCommand;
            if (string.IsNullOrEmpty(command))
            {
                return;
            }

            unit.Root().GetComponent<GameMasterComponent>().Execute(unit, command);

            await ETTask.CompletedTask;
        }
    }
}