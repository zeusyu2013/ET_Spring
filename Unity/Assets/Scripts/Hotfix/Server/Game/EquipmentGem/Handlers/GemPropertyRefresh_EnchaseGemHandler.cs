namespace ET.Server
{
    [Event(SceneType.Map)]
    public class GemPropertyRefresh_EnchaseGemHandler : AEvent<Scene, EnchaseGem>
    {
        protected override async ETTask Run(Scene scene, EnchaseGem args)
        {
            Unit unit = args.Unit;

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                Log.Error($"未找到对象数值组件:{unit.ConfigId}");
                return;
            }

            int oldGemConfigId = args.OldGem;
            if (oldGemConfigId != 0)
            {
                GemConfig oldGemConfig = GemConfigCategory.Instance.Get(oldGemConfigId);
                numericComponent.RemovePropertyPack(oldGemConfig.Property);
            }

            int newGemConfigId = args.NewGem;
            if (newGemConfigId < 1)
            {
                return;
            }

            GemConfig newGemConfig = GemConfigCategory.Instance.Get(newGemConfigId);
            numericComponent.AddPropertyPack(newGemConfig.Property);
            
            // 刷新战斗力
            unit.GetComponent<FightScoreComponent>().RefreshFightScore();

            await ETTask.CompletedTask;
        }
    }
}