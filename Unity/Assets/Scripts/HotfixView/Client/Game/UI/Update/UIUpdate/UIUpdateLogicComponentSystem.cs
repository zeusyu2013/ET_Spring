namespace ET.Client
{
    [EntitySystemOf(typeof(UIUpdateLogicComponent))]
    [FriendOf(typeof(UIUpdateLogicComponent))]
    public static partial class UIUpdateLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIUpdateLogicComponent self)
        {
            self.Scene().AddComponent<ResourcesUpdaterComponent>();
            
            self.UpdatePackageVersion().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this UIUpdateLogicComponent self)
        {
            
        }

        private static async ETTask UpdatePackageVersion(this UIUpdateLogicComponent self)
        {
            ResourcesUpdaterComponent updaterComponent = self.Scene().GetComponent<ResourcesUpdaterComponent>();
            if (updaterComponent == null)
            {
                Log.Error("ResourcesUpdaterComponent not found");
                return;
            }

            string packageVersion = await updaterComponent.UpdatePackageVersion();
            if (string.IsNullOrEmpty(packageVersion))
            {
                return;
            }

            bool success = await updaterComponent.UpdatePackageManifest(packageVersion);
            if (!success)
            {
                return;
            }
            
            updaterComponent.CheckDownload();
        }

        public static void OnHide(this UIUpdateLogicComponent self)
        {
        }

        public static void OnShow(this UIUpdateLogicComponent self)
        {
        }
    }
}