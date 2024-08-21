namespace ET.Server
{
    [EntitySystemOf(typeof(EquipmentContainerComponent))]
    [FriendOfAttribute(typeof(ET.Server.EquipmentContainerComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public static partial class EquipmentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.EquipmentContainerComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.EquipmentContainerComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                GameItem item = entity as GameItem;
                EquipmentConfig config = EquipmentConfigCategory.Instance.Get(item.ConfigId);
                if (config == null)
                {
                    item.Dispose();
                    continue;
                }

                int type = (int)config.EquipmentType;
                self.Equipments.Add(type, item);
            }
        }

        public static void Equip(this EquipmentContainerComponent self, long id)
        {
            BagComponent bagComponent = self.GetParent<Unit>().GetComponent<BagComponent>();
            GameItem item = bagComponent.GetChild<GameItem>(id);
            if (item == null)
            {
                return;
            }

            if (item.Config.Type != GameItemType.GameItemType_Equipment)
            {
                return;
            }

            EquipmentConfig config = EquipmentConfigCategory.Instance.Get(item.ConfigId);
            if (config == null)
            {
                return;
            }

            int type = (int)config.EquipmentType;
            GameItem old = null;
            if (self.Equipments.ContainsKey(type))
            {
                old = self.Equipments[type];
                bagComponent.AddItem(old);
                self.Equipments.Remove(type);
            }

            self.AddChild(item);
            self.Equipments.Add(type, item);

            EventSystem.Instance.Publish(self.Scene(), new EquipmentOnAdd() { Unit = self.GetParent<Unit>(), Old = old, New = item });
        }

        public static GameItem GetEquipmentByConfigId(this EquipmentContainerComponent self, int configId)
        {
            foreach ((int _, var value) in self.Equipments)
            {
                GameItem item = value;

                if (item.ConfigId == configId)
                {
                    return item;
                }
            }

            return null;
        }
    }
}