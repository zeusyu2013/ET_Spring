namespace ET.Server
{
    [Event(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.EquipmentRandomPropertiesComponent))]
    [FriendOfAttribute(typeof(ET.NumericComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class EquipmentOnAdd_PropertyRefreshHandler : AEvent<Scene, EquipmentOnAdd>
    {
        protected override async ETTask Run(Scene scene, EquipmentOnAdd a)
        {
            Unit unit = a.Unit;
            if (unit == null)
            {
                return;
            }

            if (a.Old != null)
            {
                EquipmentConfig oldConfig = EquipmentConfigCategory.Instance.Get(a.Old.ConfigId);
                foreach ((GamePropertyType key, int value) in oldConfig.BaseConfig.Properties)
                {
                    unit.IncLong(key, -value);
                }

                foreach ((int key, long value) in a.Old.GetComponent<EquipmentRandomPropertiesComponent>().RandomProperties)
                {
                    unit.IncLong((GamePropertyType)key, -value);
                }
            }

            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(a.New.ConfigId);
            foreach ((GamePropertyType key, int value) in config.BaseConfig.Properties)
            {
                unit.IncLong(key, value);
            }
            
            foreach ((int key, long value) in a.New.GetComponent<EquipmentRandomPropertiesComponent>().RandomProperties)
            {
                unit.IncLong((GamePropertyType)key, value);
            }

            await ETTask.CompletedTask;
        }
    }
}