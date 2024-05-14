/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UICreateRoleComponent))]
    [FriendOf(typeof(UICreateRoleComponent))]
    public static partial class UICreateRoleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UICreateRoleComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_NameText = self.GCanvas.GetChildAt(0) as GTextInput;
            self.GCanvas_ConfimBtn = self.GCanvas.GetChildAt(1) as GButton;
            self.GCanvas_List = self.GCanvas.GetChildAt(2) as GList;
            self.GCanvas_ModelLoader = self.GCanvas.GetChildAt(3) as GLoader;
            self.GCanvas_RaceText = self.GCanvas.GetChildAt(5) as GTextField;
            self.GCanvas_CharacterText = self.GCanvas.GetChildAt(7) as GTextField;
        }
        [EntitySystem]
        private static void Destroy(this UICreateRoleComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_NameText = null;
            self.GCanvas_ConfimBtn = null;
            self.GCanvas_List = null;
            self.GCanvas_ModelLoader = null;
            self.GCanvas_RaceText = null;
            self.GCanvas_CharacterText = null;
        }
    }
}