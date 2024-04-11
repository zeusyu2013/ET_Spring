/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIChatBig)]
    public class UIChatBigEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.ChatBig, UIName.UIChatBig);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.ChatBig, UIName.UIChatBig);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIChatBigComponent>();
            ui.AddComponent<UIChatBigLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIChatBigLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIChatBigLogicComponent>();
            logicComponent.OnHide();
        }
    }
}