namespace ET.Server
{
    [Event(SceneType.Map)]
    public class BagOnAdd_EquipmentHandler : AEvent<Scene, BagOnAdd>
    {
        protected override async ETTask Run(Scene scene, BagOnAdd a)
        {
            if (a.GameItem.Config.Type != GameItemType.GameItemType_Equipment)
            {
                return;
            }

            a.GameItem.AddComponent<EquipmentRandomPropertiesComponent>();

            await ETTask.CompletedTask;
        }
    }
}