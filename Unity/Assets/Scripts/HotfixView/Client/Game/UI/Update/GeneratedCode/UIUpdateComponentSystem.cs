/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIUpdateComponent))]
    [FriendOf(typeof(UIUpdateComponent))]
    public static partial class UIUpdateComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIUpdateComponent self)
        {
            UI ui = self.Parent as UI;
            self.Gupdate_progressbar = ui.Component.GetChildAt(1) as GProgressBar;
            self.Gupdate_progress_text = ui.Component.GetChildAt(3) as GTextField;
        }
        [EntitySystem]
        private static void Destroy(this UIUpdateComponent self)
        {
            self.Gupdate_progressbar = null;
            self.Gupdate_progress_text = null;
        }
    }
}