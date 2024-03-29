﻿namespace ET.Client
{
    [EntitySystemOf(typeof(UI))]
    [FriendOf(typeof(UI))]
    public static partial class FGUISystem
    {
        [EntitySystem]
        private static void Awake(this UI self, string packageName, string panelName)
        {
            self.PackageName = packageName;
            self.PanelName = panelName;
            
            self.AddComponent<ResourcesLoaderComponent>();
            self.AddComponent<UITweenComponent>();
            self.AddComponent<UIRedComponent>();
        }

        [EntitySystem]
        private static void Destroy(this UI self)
        {
            self.PanelName = "";
            self.Component.Dispose();
            self.Component = null;
        }
    }
}

