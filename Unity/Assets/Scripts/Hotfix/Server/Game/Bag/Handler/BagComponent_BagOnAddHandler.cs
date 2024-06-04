namespace ET.Server
{
    [Event(SceneType.Map)]
    public class BagComponent_BagOnAddHandler : AEvent<Scene, BagOnAdd>
    {
        protected override async ETTask Run(Scene scene, BagOnAdd args)
        {
            if (args.GameItem.Config.Type != GameItemType.GameItemType_Equipment)
            {
                return;
            }

            args.GameItem.AddComponent<EquipmentInfoComponent>();
            args.GameItem.AddComponent<EquipmentGemComponent>();

            await ETTask.CompletedTask;
        }
    }
}