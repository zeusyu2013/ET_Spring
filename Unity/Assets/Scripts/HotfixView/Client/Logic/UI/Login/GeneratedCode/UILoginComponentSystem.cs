/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UILoginComponent))]
    [FriendOf(typeof(UILoginComponent))]
    public static partial class UILoginComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILoginComponent self)
        {
            UI ui = self.Parent as UI;
            self.GLoginCtrl = ui.Component.GetControllerAt(0);
            self.GLoginBtn = ui.Component.GetChildAt(0) as GButton;
            self.GAccountText = ui.Component.GetChildAt(2) as GTextInput;
            self.GPasswordText = ui.Component.GetChildAt(4) as GTextInput;
            self.GEnterBtn = ui.Component.GetChildAt(6) as GButton;
        }
        [EntitySystem]
        private static void Destroy(this UILoginComponent self)
        {
            self.GLoginCtrl = null;
            self.GLoginBtn = null;
            self.GAccountText = null;
            self.GPasswordText = null;
            self.GEnterBtn = null;
        }
    }
}