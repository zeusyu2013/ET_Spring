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

            if (building.Level >= building.Config.BuildingLevelInfos.Count)
            {
                return;
            }

            BuildingLevelInfo info = building.Config.BuildingLevelInfos[building.Level];
            if (info == null)
            {
                return;
            }

            int preBuildingConfig = info.LimitBuildingConfig;
            int preBuildingLevel = info.LimitLevel;
            if (preBuildingConfig != 0)
            {
                Building limitBuilding = self.Buildings.Find(x =>
                        ((Building)x).ConfigId == preBuildingConfig &&
                        ((Building)x).Level >= preBuildingLevel);
                if (limitBuilding == null)
                {
                    return;
                }
            }

            bool ret = self.GetParent<Unit>().GetComponent<CurrencyComponent>().Dec(info.UpgradeCurrencyType, info.UpgradeCurrencyValue, "建筑升级");
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

                if (!building.Config.BuildingLevelInfos.TryGetValue(building.Level, out BuildingLevelInfo info))
                {
                    continue;
                }

                if (produces.ContainsKey((int)info.ProduceCurrencyType))
                {
                    produces[(int)info.ProduceCurrencyType] += info.ProduceCurrencyValue;
                }
                else
                {
                    produces.Add((int)info.ProduceCurrencyType, info.ProduceCurrencyValue);
                }
            }

            foreach ((int type, long value) in produces)
            {
                unit.GetComponent<CurrencyComponent>().Inc((CurrencyType)type, value, "建筑产出");
            }
        }
    }
}