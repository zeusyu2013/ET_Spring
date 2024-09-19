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
            self.Gupdate_progressbar = ui.Component.GetChildAt(0) as GProgressBar;
            self.Gtips1 = ui.Component.GetChildAt(1) as GTextField;
            self.Gtips2 = ui.Component.GetChildAt(2) as GTextField;
        }
        [EntitySystem]
        private static void Destroy(this UIUpdateComponent self)
        {
            self.Gupdate_progressbar = null;
            self.Gtips1 = null;
            self.Gtips2 = null;
        }
    }
}