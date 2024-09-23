/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UILoginPanelComponent))]
    [FriendOf(typeof(UILoginPanelComponent))]
    public static partial class UILoginPanelComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILoginPanelComponent self)
        {
            UI ui = self.Parent as UI;
            self.Ginput_account = ui.Component.GetChildAt(1) as GComponent;
            self.Gaccount_password = ui.Component.GetChildAt(2) as GComponent;
            self.Glogin_btn = ui.Component.GetChildAt(3) as GButton;
            self.Gnotice_btn = ui.Component.GetChildAt(4) as GButton;
            self.Guser_btn = ui.Component.GetChildAt(5) as GButton;
        }
        [EntitySystem]
        private static void Destroy(this UILoginPanelComponent self)
        {
            self.Ginput_account = null;
            self.Gaccount_password = null;
            self.Glogin_btn = null;
            self.Gnotice_btn = null;
            self.Guser_btn = null;
        }
    }
}