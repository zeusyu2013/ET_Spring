namespace ET.Server
{
    [NumericWatcher(SceneType.RoundBattle, (int)GamePropertyType.GP_BattleSpeed)]
    public class BattleSpeed_NumericWatcher : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            
        }
    }
}