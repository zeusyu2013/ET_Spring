using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.HeightSyncComponent))]
    public class AfterUnitCreate_CreateUnitView : AEvent<Scene, AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {
            Unit unit = args.Unit;

            UnitConfig config = UnitConfigCategory.Instance.Get(unit.ConfigId);
            if (config == null)
            {
                return;
            }

            // Unit View层
            string assetsName = $"Assets/Bundles/Unit/{config.Model}.prefab";
            GameObject bundleGameObject = await scene.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

            GlobalComponent globalComponent = scene.Root().GetComponent<GlobalComponent>();
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject, globalComponent.Unit, true);
            unit.AddComponent<GameObjectComponent>().GameObject = go;
            HeightSyncComponent heightSyncComponent = unit.AddComponent<HeightSyncComponent>();
            unit.Position = new(unit.Position.x, heightSyncComponent.Height, unit.Position.z);
            go.transform.position = unit.Position;

            if (unit.Type() != UnitType.UnitType_Bullet)
            {
                unit.AddComponent<AnimatorComponent>();
            }

            if (unit.Type() == UnitType.UnitType_Player)
            {
                unit.AddComponent<CameraComponent>();
            }

            await ETTask.CompletedTask;
        }
    }
}