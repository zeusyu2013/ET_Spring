/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIChatMiniComponent))]
    [FriendOf(typeof(UIChatMiniComponent))]
    public static partial class UIChatMiniComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIChatMiniComponent self)
        {
            UI ui = self.Parent as UI;
            self.GCanvas = ui.Component.GetChildAt(0) as GComponent;
            self.GCanvas_Chat = self.GCanvas.GetChildAt(0) as GComponent;
            self.GCanvas_Chat_List = self.GCanvas_Chat.GetChildAt(1) as GList;
        }
        [EntitySystem]
        private static void Destroy(this UIChatMiniComponent self)
        {
            self.GCanvas = null;
            self.GCanvas_Chat = null;
            self.GCanvas_Chat_List = null;
        }
    }
}