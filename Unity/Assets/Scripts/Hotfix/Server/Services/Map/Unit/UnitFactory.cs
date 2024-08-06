using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(Mail))]
    [FriendOf(typeof(UnitPlayerIdComponent))]
    [FriendOfAttribute(typeof(ET.Server.LocationComponent))]
    [FriendOfAttribute(typeof(ET.Server.LotteryComponent))]
    [FriendOfAttribute(typeof(ET.Server.BulletComponent))]
    [FriendOfAttribute(typeof(ET.Server.TrapComponent))]
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

            // 数值组件
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            foreach (var kv in config.BasePropertyConfig.Properties)
            {
                numericComponent.Set(kv.Key, kv.Value);
            }

            // 移动组件
            unit.AddComponent<MoveComponent>();

            // 技能释放组件
            unit.AddComponent<CastComponent>();
            unit.AddComponent<SkillStatusComponent>();

            // 背包组件
            BagComponent bagComponent = unit.AddComponentWithId<BagComponent>(unit.Id);
            foreach ((int itemConfigId, long amount) in config.Items)
            {
                bagComponent.AddItem(itemConfigId, amount);
            }

            // 等级经验组件
            unit.AddComponentWithId<LevelComponent, int>(unit.Id, 1);

            // 装备组件
            unit.AddComponentWithId<EquipmentContainerComponent>(unit.Id);

            // 邮箱组件
            MailComponent mailComponent = unit.AddComponentWithId<MailComponent>(unit.Id);
            mailComponent.AddMail("欢迎", "欢迎");

            // 副业组件
            unit.AddComponentWithId<AvocationComponent>(unit.Id);

            // 建筑组件
            unit.AddComponentWithId<BuildingComponent>(unit.Id);

            // 货币组件
            CurrencyComponent currencyComponent = unit.AddComponentWithId<CurrencyComponent>(unit.Id);
            bool ret = currencyComponent.Inc(config.CurrencyType, config.CurrencyValue, "创角初始奖励");
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

            // 位置组件
            LocationComponent locationComponent = unit.AddComponentWithId<LocationComponent>(unit.Id);
            BornSceneConfig bornSceneConfig = BornSceneConfigCategory.Instance.Get(race);
            locationComponent.SceneName = bornSceneConfig.BornScene;

            // 坐骑组件
            unit.AddComponentWithId<MountComponent>(unit.Id);

            // 付费组件
            unit.AddComponentWithId<PayComponent>(unit.Id);

            // VIP组件
            unit.AddComponentWithId<VipComponent>(unit.Id);

            // 宝箱组件
            LotteryComponent lotteryComponent = unit.AddComponentWithId<LotteryComponent>(unit.Id);
            lotteryComponent.Level = 1;

            // buff组件
            unit.AddComponentWithId<BuffComponent>(unit.Id);

            unitComponent.Add(unit);

            UnitDBSaveComponent unitDBSaveComponent = unit.AddComponent<UnitDBSaveComponent>();
            unitDBSaveComponent.AddChange(typeof(LevelComponent));
            unitDBSaveComponent.AddChange(typeof(BagComponent));
            unitDBSaveComponent.AddChange(typeof(EquipmentContainerComponent));
            unitDBSaveComponent.AddChange(typeof(MailComponent));
            unitDBSaveComponent.AddChange(typeof(AvocationComponent));
            unitDBSaveComponent.AddChange(typeof(BuildingComponent));
            unitDBSaveComponent.AddChange(typeof(CurrencyComponent));
            unitDBSaveComponent.AddChange(typeof(OfflineIncomeComponent));
            unitDBSaveComponent.AddChange(typeof(GameTaskComponent));
            unitDBSaveComponent.AddChange(typeof(AchievementComponent));
            unitDBSaveComponent.AddChange(typeof(LocationComponent));
            unitDBSaveComponent.AddChange(typeof(MountComponent));
            unitDBSaveComponent.AddChange(typeof(PayComponent));
            unitDBSaveComponent.AddChange(typeof(VipComponent));
            unitDBSaveComponent.AddChange(typeof(LotteryComponent));
            unitDBSaveComponent.AddChange(typeof(BuffComponent));
            unitDBSaveComponent.SaveChanged();

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

            // todo:角色属性应该在加载所有组件后再计算一次并存入数值组件
            // NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            // UnitConfig config = UnitConfigCategory.Instance.Get(unit.ConfigId);
            // foreach (var kv in config.PropertyConfig.Properties)
            // {
            //     numericComponent.Set((int)kv.Key, kv.Value);
            // }

            // 从缓存服拉去玩家相关组件数据，过期被清除的数据从数据库中拉取并存储在缓存服上
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
            unit.AddComponent<CastComponent>();

            // 加入aoi
            unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            return unit;
        }

        public static Unit CreateBullet(Scene scene, long ownerId, int unitConfigId, int bulletId, float3 pos, quaternion rotation)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit bullet = unitComponent.AddChild<Unit, int>(unitConfigId);
            bullet.Position = pos;
            bullet.Rotation = rotation;

            bullet.AddComponent<CastComponent>();
            bullet.AddComponent<MoveComponent>();
            bullet.AddComponent<PathfindingComponent, string>(scene.Name);
            NumericComponent numericComponent = bullet.AddComponent<NumericComponent>();
            numericComponent.Set(GamePropertyType.GP_Speed, 6f);
            numericComponent.Set(GamePropertyType.GP_AOI, 15000);

            BulletComponent bulletComponent = bullet.AddComponent<BulletComponent, int>(bulletId);
            bulletComponent.OwnerId = ownerId;
            unitComponent.Add(bullet);

            bullet.AddComponent<AOIEntity, int, float3>(9 * 1000, bullet.Position);

            return bullet;
        }

        public static Unit CreateMonster(Scene scene, int unitConfigId, float3 pos)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit monster = unitComponent.AddChild<Unit, int>(unitConfigId);
            monster.AddComponent<MoveComponent>();
            monster.AddComponent<PathfindingComponent, string>(scene.Name);
            monster.Position = pos;

            NumericComponent numericComponent = monster.AddComponent<NumericComponent>();
            MonsterConfig config = MonsterConfigCategory.Instance.Get(unitConfigId);
            numericComponent.AddPropertyPack(config.PropertyPack);

            monster.AddComponent<ReliveComponent>();
            monster.AddComponent<CastComponent>();
            monster.AddComponent<BuffComponent>();

            unitComponent.Add(monster);

            return monster;
        }

        public static Unit CreateTrap(Scene scene, long ownerId, int unitConfigId, int trapConfigId, float3 pos, quaternion rotation)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit trap = unitComponent.AddChild<Unit, int>(unitConfigId);
            trap.Position = pos;
            trap.Rotation = rotation;

            trap.AddComponent<CastComponent>();

            NumericComponent numericComponent = trap.AddComponent<NumericComponent>();
            numericComponent.Set(GamePropertyType.GP_AOI, 15000);

            TrapComponent trapComponent = trap.AddComponent<TrapComponent, int>(trapConfigId);
            trapComponent.OwnerId = ownerId;
            unitComponent.Add(trap);

            trap.AddComponent<AOIEntity, int, float3>(9 * 1000, trap.Position);

            return trap;
        }
    }
}