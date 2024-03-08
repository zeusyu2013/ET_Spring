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
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_LoginCtrl = self.GCanvas.GetControllerAt(0);
            self.GCanvas_LoginBtn = self.GCanvas.GetChildAt(0) as GButton;
            self.GCanvas_AccountText = self.GCanvas.GetChildAt(2) as GTextInput;
            self.GCanvas_PasswordText = self.GCanvas.GetChildAt(4) as GTextInput;
            self.GCanvas_SelectServerBtn = self.GCanvas.GetChildAt(6) as GButton;
            self.GCanvas_ServerNameBg = self.GCanvas.GetChildAt(7) as GGraph;
            self.GCanvas_ServerName = self.GCanvas.GetChildAt(8) as GTextField;
        }
        [EntitySystem]
        private static void Destroy(this UILoginComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_LoginCtrl = null;
            self.GCanvas_LoginBtn = null;
            self.GCanvas_AccountText = null;
            self.GCanvas_PasswordText = null;
            self.GCanvas_SelectServerBtn = null;
            self.GCanvas_ServerNameBg = null;
            self.GCanvas_ServerName = null;
        }
    }
}