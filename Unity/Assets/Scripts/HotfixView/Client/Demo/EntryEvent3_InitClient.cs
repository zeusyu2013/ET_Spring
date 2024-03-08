
namespace ET.Client
{
    [Event(SceneType.Main)]
    public class EntryEvent3_InitClient: AEvent<Scene, EntryEvent3>
    {
        protected override async ETTask Run(Scene root, EntryEvent3 args)
        {
            GlobalComponent globalComponent = root.AddComponent<GlobalComponent>();
            root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<InputComponent>();
            root.AddComponent<UIComponent>();
            root.AddComponent<GameRoleInfoComponent>();
            root.AddComponent<RemoteConfigComponent>();
            root.AddComponent<PlayerPrefsComponent>();
            root.AddComponent<MapleComponent>();
            
            // 根据配置修改掉Main Fiber的SceneType
            SceneType sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;
            
            await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
        }
    }
}