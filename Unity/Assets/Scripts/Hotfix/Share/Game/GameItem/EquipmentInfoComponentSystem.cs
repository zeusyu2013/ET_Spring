namespace ET
{
    [EntitySystemOf(typeof(EquipmentInfoComponent))]
    [FriendOfAttribute(typeof(ET.EquipmentInfoComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public static partial class EquipmentInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.EquipmentInfoComponent self)
        {
            self.InitEquipmentBaseProperties();
            self.InitEquipmentRandomProperties();
        }

        [EntitySystem]
        private static void Destroy(this ET.EquipmentInfoComponent self)
        {
        }

        public static void InitEquipmentBaseProperties(this EquipmentInfoComponent self)
        {
            if (self.EquipmentBaseProperties.Count > 0)
            {
                return;
            }

            int configId = self.GetParent<GameItem>().ConfigId;
            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                return;
            }

            foreach ((GamePropertyType type, int value) in config.BaseConfig.Properties)
            {
                self.EquipmentBaseProperties.Add((int)type, value);
            }
        }

        public static void InitEquipmentRandomProperties(this EquipmentInfoComponent self)
        {
            if (self.EquipmentRandomProperties.Count > 0)
            {
                return;
            }

            int configId = self.GetParent<GameItem>().ConfigId;
            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                return;
            }

            foreach ((GamePropertyType type, MinMax value) in config.RandomConfig.Properties)
            {
                long current = RandomGenerator.RandomNumber((int)value.Min, (int)value.Max);
                self.EquipmentRandomProperties.Add((int)type, current);
            }
        }
    }
}