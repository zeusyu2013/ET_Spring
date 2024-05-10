using System;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.Mail))]
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

                    BagComponent bagComponent = unit.AddComponentWithId<BagComponent>(unit.Id);
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

        public static Unit CreateCharacter(Scene scene, long id, CharacterType character, RaceType race)
        {
            // 检查职业种族对应
            CreateRoleConfig config = CreateRoleConfigCategory.Instance.Get(character);
            bool vaild = (config.RaceFlag & race) == race;
            if (!vaild)
            {
                return null;
            }

            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 0);

            // 数值组件
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            foreach (var kv in config.BasePropertyConfig.Properties)
            {
                numericComponent.Set(kv.Key, kv.Value);
            }

            // 移动组件
            unit.AddComponent<MoveComponent>();

            // 背包组件
            BagComponent bagComponent = unit.AddComponent<BagComponent>();
            foreach ((int itemConfigId, int amount) in config.Items)
            {
                bagComponent.AddItem(itemConfigId, amount);
            }

            // 装备组件
            unit.AddComponent<EquipmentComponent>();

            // 邮箱组件
            MailComponent mailComponent = unit.AddComponent<MailComponent>();
            mailComponent.AddMail("欢迎", "欢迎");

            // 副业组件
            unit.AddComponent<AvocationComponent>();

            // 建筑组件
            unit.AddComponent<BuildingComponent>();

            // 货币组件
            unit.AddComponent<CurrencyComponent>();

            // 离线收益组件
            unit.AddComponent<OfflineIncomeComponent>();

            // 任务组件
            unit.AddComponent<GameTaskComponent>();

            // 成就组件
            unit.AddComponent<AchievementComponent>();

            unitComponent.Add(unit);

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
            return unit;
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

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            UnitConfig config = UnitConfigCategory.Instance.Get(unit.ConfigId);
            foreach (var kv in config.PropertyConfig.Properties)
            {
                numericComponent.Set((int)kv.Key, kv.Value);
            }

            unit.AddComponent<MoveComponent>();

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            return unit;
        }
    }
}