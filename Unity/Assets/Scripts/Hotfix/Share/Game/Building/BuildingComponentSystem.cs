using System.Collections.Generic;

namespace ET
{
    [EntitySystemOf(typeof(BuildingComponent))]
    [FriendOfAttribute(typeof(ET.BuildingComponent))]
    [FriendOfAttribute(typeof(ET.Building))]
    public static partial class BuildingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.BuildingComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.BuildingComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                self.Buildings.Add(entity as Building);
            }
        }

        public static void AddBuilding(this BuildingComponent self, int configId)
        {
            BuildingConfig config = BuildingConfigCategory.Instance.Get(configId);
            if (config == null)
            {
                return;
            }
            
            List<EntityRef<Building>> buildings = self.Buildings.FindAll(x => ((Building)x).ConfigId == configId);
            if (buildings.Count >= config.Limit)
            {
                return;
            }

            
        }

        public static void UpgradeBuilding(this BuildingComponent self, Building building)
        {
            if (building == null)
            {
                return;
            }

            if (building.Level >= building.Config.UpgradeConsume.Count)
            {
                return;
            }

            int consume = building.Config.UpgradeConsume[building.Level];
            if (consume < 1)
            {
                return;
            }

            bool ret = self.GetParent<Unit>().GetComponent<CurrencyComponent>().Dec(CurrencyType.CurrencyType_Gold, consume);
            if (!ret)
            {
                return;
            }

            building.Level += 1;
        }
    }
}