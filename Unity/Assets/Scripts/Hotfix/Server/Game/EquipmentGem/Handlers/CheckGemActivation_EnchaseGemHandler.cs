namespace ET.Server
{
    [Event(SceneType.Map)]
    public class CheckGemActivation_EnchaseGemHandler : AEvent<Scene, EnchaseGem>
    {
        protected override async ETTask Run(Scene scene, EnchaseGem args)
        {
            Unit unit = args.Unit;
            GameItem item = args.Item;
            int holeIndex = args.HoldIndex;
            int oldGemConfigId = args.OldGem;
            int newGemConfigId = args.NewGem;

            if (oldGemConfigId != 0)
            {
                item.GetComponent<EquipmentGemComponent>().ActivationHoleProperty(holeIndex, oldGemConfigId, false);
            }
            
            item.GetComponent<EquipmentGemComponent>().ActivationHoleProperty(holeIndex, newGemConfigId, true);
            
            await ETTask.CompletedTask;
        }
    }
}