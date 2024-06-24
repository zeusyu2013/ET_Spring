using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(BuildingComponent))]
    [FriendOfAttribute(typeof(BuildingComponent))]
    [FriendOfAttribute(typeof(Building))]
    public static partial class BuildingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this BuildingComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this BuildingComponent self)
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

            Building building = self.AddChild<Building, int>(configId);
            self.Buildings.Add(building);
        }

        public static void UpgradeBuilding(this BuildingComponent self, Building building)
        {
            if (building == null)
            {
                return;
            }

            if (!self.Buildings.Contains(building))
            {
                return;
            }

            if (building.Level >= building.Config.UpgradeConsume.Count)
            {
                return;
            }

            BuildingUpgrade upgrade = building.Config.UpgradeConsume[building.Level];
            if (upgrade == null)
            {
                return;
            }

            bool ret = self.GetParent<Unit>().GetComponent<CurrencyComponent>().Dec(upgrade.CurrencyType, upgrade.CurrencyValue);
            if (!ret)
            {
                return;
            }

            building.Level += 1;
        }

        public static void GetBuildingProduce(this BuildingComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            long now = TimeInfo.Instance.ServerNow();
            if (now < self.LastProduceTime)
            {
                return;
            }

            long diff = (now - self.LastProduceTime) / 1000;
            if (diff < 1)
            {
                return;
            }

            Dictionary<int, long> produces = new();
            foreach (var buildingRef in self.Buildings)
            {
                Building building = buildingRef;
                if (building == null || building.IsDisposed)
                {
                    continue;
                }

                if (!building.Config.Produce.TryGetValue(building.Level, out BuildingProduce produce))
                {
                    continue;
                }

                if (produces.ContainsKey((int)produce.CurrencyType))
                {
                    produces[(int)produce.CurrencyType] += produce.CurrencyValue;
                }
                else
                {
                    produces.Add((int)produce.CurrencyType, produce.CurrencyValue);
                }
            }

            foreach ((int type, long value) in produces)
            {
                unit.GetComponent<CurrencyComponent>().Inc((CurrencyType)type, value);
            }
        }
    }
}