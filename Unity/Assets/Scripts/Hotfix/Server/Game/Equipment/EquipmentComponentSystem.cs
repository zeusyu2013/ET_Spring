﻿namespace ET.Server
{
    [EntitySystemOf(typeof(EquipmentComponent))]
    [FriendOfAttribute(typeof(ET.Server.EquipmentComponent))]
    public static partial class EquipmentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.EquipmentComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.EquipmentComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                GameItem item = entity as GameItem;
                self.AddChild(item);

                if (item.Config.EquipmentType == null)
                {
                    item.Dispose();
                    continue;
                }

                int type = (int)item.Config.EquipmentType;
                self.Equipments.Add(type, item);
            }
        }

        public static void Equip(this EquipmentComponent self, long id)
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

            int type = (int)item.Config.EquipmentType;
            GameItem old = null;
            if (self.Equipments.ContainsKey(type))
            {
                old = self.Equipments[type];
                bagComponent.AddChild(old);
                self.Equipments.Remove(type);
            }

            self.AddChild(item);
            self.Equipments.Add(type, item);

            EventSystem.Instance.Publish(self.Scene(), new EquipmentOnAdd() { Unit = self.GetParent<Unit>(), Old = old, New = item });
        }
    }
}