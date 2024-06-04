namespace ET.Server
{
    [FriendOf(typeof(EquipmentGemComponent))]
    [EntitySystemOf(typeof(EquipmentGemComponent))]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public static partial class EquipmentGemComponentSystem
    {
        private static void Awake(this EquipmentGemComponent self)
        {
        }

        private static void Destroy(this EquipmentGemComponent self)
        {
            self.Gems.Clear();
        }

        public static void EnchaseGem(this EquipmentGemComponent self, int gemConfigId, int holeIndex)
        {
            if (self.Config.HolesProperty.Count < holeIndex)
            {
                return;
            }

            int oldGemConfigId = 0;
            if (self.Gems.TryGetValue(holeIndex, out int gem))
            {
                oldGemConfigId = gem;
            }

            Unit unit = self.GetParent<Unit>();
            bool ret = unit.GetComponent<BagComponent>().RemoveItem(gemConfigId, 1);
            if (!ret)
            {
                return;
            }

            self.Gems.Add(holeIndex, gemConfigId);

            EventSystem.Instance.Publish(self.Root(), new EnchaseGem()
            {
                Unit = unit, 
                Item = self.GetParent<GameItem>(), 
                HoldIndex = holeIndex, 
                OldGem = oldGemConfigId, 
                NewGem = gemConfigId
            });
        }

        public static void ActivationHoleProperty(this EquipmentGemComponent self, int holeIndex, int gemConfigId, bool enchased)
        {
            if (!self.Config.HolesProperty.TryGetValue(holeIndex, out EquipmentHoles holes))
            {
                return;
            }

            GemConfig gemConfig = GemConfigCategory.Instance.Get(gemConfigId);
            if (gemConfig == null)
            {
                return;
            }

            bool activation = (gemConfig.ColorFlag & holes.HoleColor) == holes.HoleColor;
            if (!activation)
            {
                return;
            }

            if (enchased)
            {
                self.GetParent<Unit>().GetComponent<NumericComponent>().AddPropertyPack(holes.PropertyPack);    
            }
            else
            {
                self.GetParent<Unit>().GetComponent<NumericComponent>().RemovePropertyPack(holes.PropertyPack);
            }
        }
    }
}