/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIChatBigComponent))]
    [FriendOf(typeof(UIChatBigComponent))]
    public static partial class UIChatBigComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIChatBigComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_List = self.GCanvas.GetChildAt(1) as GList;
            self.GCanvas_InputText = self.GCanvas.GetChildAt(3) as GTextInput;
            self.GCanvas_SendBtn = self.GCanvas.GetChildAt(4) as GButton;
        }
        [EntitySystem]
        private static void Destroy(this UIChatBigComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_List = null;
            self.GCanvas_InputText = null;
            self.GCanvas_SendBtn = null;
        }
    }
}