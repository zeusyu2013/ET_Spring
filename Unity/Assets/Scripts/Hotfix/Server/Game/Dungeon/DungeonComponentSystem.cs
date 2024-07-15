using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(DungeonComponent))]
    [FriendOfAttribute(typeof(ET.Server.DungeonComponent))]
    public static partial class DungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DungeonComponent self)
        {
        }

        public static ActorId EnterDungeon(this DungeonComponent self, int dungeonConfig, long unitId)
        {
            if (self.DungeonScenes.TryGetValue(unitId, out EntityRef<Scene> sceneRef))
            {
                Scene scene = sceneRef;
                return scene.GetActorId();
            }

            Scene newScene = self.CreateDungeon(dungeonConfig, unitId);

            self.DungeonScenes.Add(unitId, newScene);

            return newScene.GetActorId();
        }

        private static Scene CreateDungeon(this DungeonComponent self, int dungeonConfig, long unitId)
        {
            DungeonConfig config = DungeonConfigCategory.Instance.Get(dungeonConfig);
            if (config == null)
            {
                return null;
            }

            Scene scene = EntitySceneFactory.CreateScene(self.Root(), unitId, IdGenerater.Instance.GenerateInstanceId(), SceneType.Map,
                config.SceneConfig.SceneRes);
            scene.AddComponent<UnitComponent>();
            scene.AddComponent<AOIManagerComponent>();
            scene.AddComponent<MessageSender>();
            scene.AddComponent<LocationProxyComponent>();
            scene.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);

            return scene;
        }

        public static void ExitDungeon(this DungeonComponent self, long unitId)
        {
            if (!self.DungeonScenes.TryGetValue(unitId, out EntityRef<Scene> sceneRef))
            {
                return;
            }

            Scene scene = sceneRef;
            scene.Dispose();
            
            self.DungeonScenes.Remove(unitId);
        }
    }
}