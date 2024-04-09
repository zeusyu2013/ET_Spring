/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIMainComponent))]
    [FriendOf(typeof(UIMainComponent))]
    public static partial class UIMainComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_Test1 = self.GCanvas.GetChildAt(0) as GButton;
            self.GCanvas_Test2 = self.GCanvas.GetChildAt(1) as GButton;
            self.GCanvas_Test3 = self.GCanvas.GetChildAt(2) as GButton;
            self.GCanvas_Test4 = self.GCanvas.GetChildAt(3) as GButton;
            self.GCanvas_PingText = self.GCanvas.GetChildAt(4) as GTextField;
        }
        [EntitySystem]
        private static void Destroy(this UIMainComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_Test1 = null;
            self.GCanvas_Test2 = null;
            self.GCanvas_Test3 = null;
            self.GCanvas_Test4 = null;
            self.GCanvas_PingText = null;
        }
    }
}