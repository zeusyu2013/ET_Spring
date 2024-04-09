using System;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);

                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    numericComponent.Set(GamePropertyType.GamePropertyType_Speed, 6f); // 速度是6米每秒
                    numericComponent.Set(GamePropertyType.GamePropertyType_AOI, 15000); // 视野15米

                    UnitConfig config = UnitConfigCategory.Instance.Get(1001);
                    foreach (var kv in config.PropertyConfig.Properties)
                    {
                        numericComponent.Set((int)kv.Key, kv.Value);
                    }

                    BagComponent bagComponent = unit.AddComponent<BagComponent>();
                    bagComponent.AddItem(60011, 1);

                    unit.AddComponent<MailComponent>();

                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }

        public static async ETTask<Unit> LoadFromDB(Scene scene, long unitId)
        {
            Unit unit = null;
            var units = await scene.GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone()).Query<Unit>(x => x.Id == unitId);
            if (units.Count < 1)
            {
                return null;
            }

            unit = units[0];
            if (unit == null)
            {
                return null;
            }

            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            unitComponent.AddChild(unit);

            unit.AddComponent<BagComponent>();
            unit.AddComponent<MailComponent>();
            unit.AddComponent<NumericComponent>();
            unit.AddComponent<MoveComponent>();

            return unit;
        }
    }
}