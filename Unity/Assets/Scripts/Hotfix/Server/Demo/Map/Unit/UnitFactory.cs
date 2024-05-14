using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(Mail))]
    [FriendOf(typeof(UnitPlayerIdComponent))]
    public static partial class UnitFactory
    {
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
            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, config.ConfigId);

            unit.AddComponent<UnitDBSaveComponent>();

            // 数值组件
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            foreach (var kv in config.BasePropertyConfig.Properties)
            {
                numericComponent.Set(kv.Key, kv.Value);
            }

            // 移动组件
            unit.AddComponent<MoveComponent>();

            // 背包组件
            BagComponent bagComponent = unit.AddComponentWithId<BagComponent>(unit.Id);
            foreach ((int itemConfigId, long amount) in config.Items)
            {
                bagComponent.AddItem(itemConfigId, amount);
            }

            // 装备组件
            unit.AddComponentWithId<EquipmentComponent>(unit.Id);

            // 邮箱组件
            MailComponent mailComponent = unit.AddComponentWithId<MailComponent>(unit.Id);
            mailComponent.AddMail("欢迎", "欢迎");

            // 副业组件
            unit.AddComponentWithId<AvocationComponent>(unit.Id);

            // 建筑组件
            unit.AddComponentWithId<BuildingComponent>(unit.Id);

            // 货币组件
            CurrencyComponent currencyComponent = unit.AddComponentWithId<CurrencyComponent>(unit.Id);
            bool ret = currencyComponent.Inc(config.CurrencyType, config.CurrencyValue);
            if (!ret)
            {
                Log.Warning("创建角色添加货币失败");
            }

            // 离线收益组件
            unit.AddComponentWithId<OfflineIncomeComponent>(unit.Id);

            // 任务组件
            GameTaskComponent gameTaskComponent = unit.AddComponentWithId<GameTaskComponent>(unit.Id);
            gameTaskComponent.AcceptTask(config.TaskId);

            // 成就组件
            unit.AddComponentWithId<AchievementComponent>(unit.Id);

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

            unit.AddComponent<UnitDBSaveComponent>();

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            UnitConfig config = UnitConfigCategory.Instance.Get(unit.ConfigId);
            foreach (var kv in config.PropertyConfig.Properties)
            {
                numericComponent.Set((int)kv.Key, kv.Value);
            }

            // TODO：从缓存服拉去玩家相关组件数据
            List<byte[]> entities = await DBCacheHelper.GetCache(scene, unitId);
            if (entities.Count > 0)
            {
                foreach (byte[] bytes in entities)
                {
                    Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                    unit.AddComponent(entity);
                }
            }

            unit.AddComponent<MoveComponent>();

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            return unit;
        }
    }
}