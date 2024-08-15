/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIBagComponent))]
    [FriendOf(typeof(UIBagComponent))]
    public static partial class UIBagComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIBagComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_TabCtrl = self.GCanvas.GetControllerAt(0);
            self.GCanvas_List = self.GCanvas.GetChildAt(1) as GComponent;
            self.GCanvas_List_List = self.GCanvas_List.GetChildAt(1) as GList;
            self.GCanvas_CloseBtn = self.GCanvas.GetChildAt(2) as GButton;
            self.GCanvas_Tab1 = self.GCanvas.GetChildAt(3) as GButton;
            self.GCanvas_Tab2 = self.GCanvas.GetChildAt(4) as GButton;
            self.GCanvas_Tab3 = self.GCanvas.GetChildAt(5) as GButton;
            self.GCanvas_Tab4 = self.GCanvas.GetChildAt(6) as GButton;
        }
        [EntitySystem]
        private static void Destroy(this UIBagComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_TabCtrl = null;
            self.GCanvas_List = null;
            self.GCanvas_List_List = null;
            self.GCanvas_CloseBtn = null;
            self.GCanvas_Tab1 = null;
            self.GCanvas_Tab2 = null;
            self.GCanvas_Tab3 = null;
            self.GCanvas_Tab4 = null;
        }
    }
}