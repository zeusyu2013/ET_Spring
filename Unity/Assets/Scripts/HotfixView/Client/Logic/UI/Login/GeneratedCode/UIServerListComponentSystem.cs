/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIServerListComponent))]
    [FriendOf(typeof(UIServerListComponent))]
    public static partial class UIServerListComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIServerListComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_ServerList = self.GCanvas.GetChildAt(2) as GList;
            self.GCanvas_CloseBtn = self.GCanvas.GetChildAt(3) as GButton;
            self.GCanvas_DisList = self.GCanvas.GetChildAt(4) as GList;
        }
        [EntitySystem]
        private static void Destroy(this UIServerListComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_ServerList = null;
            self.GCanvas_CloseBtn = null;
            self.GCanvas_DisList = null;
        }
    }
}