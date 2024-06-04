namespace ET.Server
{
    [Event(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.EquipmentRandomPropertiesComponent))]
    [FriendOfAttribute(typeof(ET.NumericComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class EquipmentOnAdd_PropertyRefreshHandler : AEvent<Scene, EquipmentOnAdd>
    {
        protected override async ETTask Run(Scene scene, EquipmentOnAdd args)
        {
            Unit unit = args.Unit;
            if (unit == null)
            {
                return;
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            if (numericComponent == null)
            {
                Log.Error($"未找到指定对象数值组件:{unit.ConfigId}");
                return;
            }

            if (args.Old != null)
            {
                EquipmentConfig oldConfig = EquipmentConfigCategory.Instance.Get(args.Old.ConfigId);
                numericComponent.RemovePropertyPack(oldConfig.Base);

                foreach ((int key, long value) in args.Old.GetComponent<EquipmentRandomPropertiesComponent>().RandomProperties)
                {
                    unit.DecLong((GamePropertyType)key, value);
                }
            }

            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(args.New.ConfigId);
            numericComponent.AddPropertyPack(config.Base);
            
            foreach ((int key, long value) in args.New.GetComponent<EquipmentRandomPropertiesComponent>().RandomProperties)
            {
                unit.IncLong((GamePropertyType)key, value);
            }

            await ETTask.CompletedTask;
        }
    }
}