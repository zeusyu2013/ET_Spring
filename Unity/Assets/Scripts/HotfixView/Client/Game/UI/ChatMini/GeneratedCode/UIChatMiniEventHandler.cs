/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIChatMini)]
    public class UIChatMiniEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.ChatMini, UIName.UIChatMini);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.ChatMini, UIName.UIChatMini);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIChatMiniComponent>();
            ui.AddComponent<UIChatMiniLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIChatMiniLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIChatMiniLogicComponent>();
            logicComponent.OnHide();
        }
    }
}