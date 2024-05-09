namespace ET.Server
{
    [EntitySystemOf(typeof(EquipmentRandomPropertiesComponent))]
    [FriendOfAttribute(typeof(ET.Server.EquipmentRandomPropertiesComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public static partial class EquipmentRandomPropertiesComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.EquipmentRandomPropertiesComponent self)
        {
            self.RandomProperties.Clear();

            self.GenRandomProperties();
        }

        public static void GenRandomProperties(this EquipmentRandomPropertiesComponent self)
        {
            int configId = self.GetParent<GameItem>().ConfigId;
            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                return;
            }

            foreach ((GamePropertyType key, MinMax value) in config.RandomConfig.Properties)
            {
                long random = RandomGenerator.RandomNumber((int)value.Min, (int)value.Max);
                self.RandomProperties.Add((int)key, random);
            }
        }
    }
}