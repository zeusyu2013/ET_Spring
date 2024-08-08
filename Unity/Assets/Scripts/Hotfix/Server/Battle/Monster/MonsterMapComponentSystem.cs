using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(MonsterMapComponent))]
    public static partial class MonsterMapComponentSystem
    {
        [Invoke(TimerInvokeType.CreateMonsterTimer)]
        [FriendOfAttribute(typeof(ET.Server.CreateMonsterInfo))]
        public class CreateMonsterTimer : ATimer<CreateMonsterInfo>
        {
            protected override void Run(CreateMonsterInfo self)
            {
                self.GetParent<MonsterMapComponent>().CreateMonster(self.MonsterConfigId);
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.MonsterMapComponent self)
        {
            if (self.Scene().Name.Equals("GateMap"))
            {
                return;
            }

            foreach (SceneMonsterConfig sceneMonsterConfig in SceneMonsterConfigCategory.Instance.DataList)
            {
                self.CreateMonsterByGroup(sceneMonsterConfig.Id);
            }
        }

        public static void CreateMonsterByGroup(this MonsterMapComponent self, int groupId)
        {
            SceneMonsterConfig config = SceneMonsterConfigCategory.Instance.Get(groupId);
            int range = config.RandomRange / 2;

            for (int i = 0; i < config.Monsters.MonsterCount; i++)
            {
                float3 pos = new float3(config.Position.X, config.Position.Y, config.Position.Z) +
                        new float3(RandomGenerator.RandomNumber(-range, range), 0, RandomGenerator.RandomNumber(-range, range));

                Unit monster = UnitFactory.CreateMonster(self.Scene(), config.Monsters.MonsterConfig, pos);
                monster.AddComponent<MonsterComponent, int>(config.Id);

                monster.AddComponent<AOIEntity, int, float3>(9 * 1000, monster.Position);
            }
        }

        private static void CreateMonster(this MonsterMapComponent self, int groupId)
        {
            SceneMonsterConfig config = SceneMonsterConfigCategory.Instance.Get(groupId);
            int range = config.RandomRange / 2;

            //for (int i = 0; i < config.Monsters.MonsterCount; i++)
            {
                float3 pos = new float3(config.Position.X, config.Position.Y, config.Position.Z) +
                        new float3(RandomGenerator.RandomNumber(-range, range), 0, RandomGenerator.RandomNumber(-range, range));

                Unit monster = UnitFactory.CreateMonster(self.Scene(), config.Monsters.MonsterConfig, pos);
                monster.AddComponent<MonsterComponent, int>(config.Id);

                monster.AddComponent<AOIEntity, int, float3>(9 * 1000, monster.Position);
            }
        }

        public static void OnMonsterDead(this MonsterMapComponent self, int groupConfigId)
        {
            SceneMonsterConfig config = SceneMonsterConfigCategory.Instance.Get(groupConfigId);
            long reliveTime = TimeInfo.Instance.ServerNow() + config.ReliveTime;
            self.Scene().GetComponent<TimerComponent>().NewOnceTimer(reliveTime, TimerInvokeType.CreateMonsterTimer,
                self.AddChild<CreateMonsterInfo, int>(groupConfigId));
        }
    }
}