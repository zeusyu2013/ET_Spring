/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIChatBigLogicComponent))]
    [FriendOf(typeof(UIChatBigLogicComponent))]
    public static partial class UIChatBigLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIChatBigLogicComponent self)
        {
            var view = self.GetParent<UI>().GetParent<UIChatBigComponent>();
            // 发送聊天消息
            view.GCanvas_SendBtn.onClick.Set(()=>
            {
                string content = view.GCanvas_InputText.text;
                if (string.IsNullOrEmpty(content))
                {
                    return;
                }
                
            });
            
            view.GCanvas_List.SetVirtual();
            view.GCanvas_List.itemRenderer = self.ChatItemRenderer;
        }
        [EntitySystem]
        private static void Destroy(this UIChatBigLogicComponent self)
        {
        }
        public static void OnHide(this UIChatBigLogicComponent self)
        {
        }

        public static void OnShow(this UIChatBigLogicComponent self)
        {
        }

        
        public static void ChatItemRenderer(this UIChatBigLogicComponent self, int index, GObject obj)
        {
            
        }
    }
}