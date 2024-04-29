namespace ET
{
    [EntitySystemOf(typeof(AppearanceComponent))]
    [FriendOfAttribute(typeof(ET.AppearanceComponent))]
    public static partial class AppearanceComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.AppearanceComponent self)
        {
        }

        public static void ModifyAppearance(this AppearanceComponent self, int modelConfig, int weaponConfig)
        {
            self.ModelConfig = modelConfig;
            self.WeaponConfig = weaponConfig;

            EventSystem.Instance.Publish(self.Root(), new AppearanceChanged() { ModelConfig = self.ModelConfig, WeaponConfig = self.WeaponConfig });
        }
    }
}