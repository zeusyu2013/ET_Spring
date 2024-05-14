/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIChooseRoleComponent))]
    [FriendOf(typeof(UIChooseRoleComponent))]
    public static partial class UIChooseRoleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIChooseRoleComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_List = self.GCanvas.GetChildAt(0) as GList;
            self.GCanvas_EnterBtn = self.GCanvas.GetChildAt(1) as GButton;
            self.GCanvas_DeleteBtn = self.GCanvas.GetChildAt(2) as GButton;
            self.GCanvas_RaceText = self.GCanvas.GetChildAt(4) as GTextField;
            self.GCanvas_CharacterText = self.GCanvas.GetChildAt(6) as GTextField;
            self.GCanvas_IconLoader = self.GCanvas.GetChildAt(7) as GLoader;
        }
        [EntitySystem]
        private static void Destroy(this UIChooseRoleComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_List = null;
            self.GCanvas_EnterBtn = null;
            self.GCanvas_DeleteBtn = null;
            self.GCanvas_RaceText = null;
            self.GCanvas_CharacterText = null;
            self.GCanvas_IconLoader = null;
        }
    }
}