namespace ET.Server
{
    [Event(SceneType.RoundBattle)]
    [FriendOfAttribute(typeof(ET.Server.RoundBattleComponent))]
    public class ProgressCompleteHandler : AEvent<Scene, ProgressComplete>
    {
        protected override async ETTask Run(Scene scene, ProgressComplete args)
        {
            RoundBattleComponent roundBattleComponent = scene.GetComponent<RoundBattleComponent>();

            roundBattleComponent.Pause(true);

            Unit unit = roundBattleComponent.Owner;
            
            if (args.Unit.Type() == UnitType.UnitType_Monster)
            {

            }
            else
            {
                RoundBattleMessageHelper.SendMessage(scene);
            }

            await ETTask.CompletedTask;
        }
    }
}