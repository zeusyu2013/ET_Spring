using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(EquipmentInfoComponent))]
    [FriendOfAttribute(typeof(EquipmentInfoComponent))]
    [FriendOfAttribute(typeof(GameItem))]
    public static partial class EquipmentInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this EquipmentInfoComponent self)
        {
            self.InitEquipmentBaseProperties();
            self.InitEquipmentRandomProperties();
        }

        [EntitySystem]
        private static void Destroy(this EquipmentInfoComponent self)
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

        public static void RerandomProperties(this EquipmentInfoComponent self)
        {
            int configId = self.GetParent<GameItem>().ConfigId;
            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                return;
            }
            
            self.EquipmentRandomProperties.Clear();
            
            foreach ((GamePropertyType type, MinMax value) in config.RandomConfig.Properties)
            {
                long current = RandomGenerator.RandomNumber((int)value.Min, (int)value.Max);
                self.EquipmentRandomProperties.Add((int)type, current);
            }
        }

        public static List<EquipmentRandomProperty> ToMessage(this EquipmentInfoComponent self)
        {
            List<EquipmentRandomProperty> properties = new();
            foreach ((int type, long value) in self.EquipmentRandomProperties)
            {
                EquipmentRandomProperty property = EquipmentRandomProperty.Create();
                property.GamePropertyType = type;
                property.GamePropertyValue = value;
                
                properties.Add(property);
            }

            return properties;
        }
    }
}