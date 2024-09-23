/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UILoginPanel)]
    public class UILoginPanelEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Login, UIName.UILoginPanel);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.Login, UIName.UILoginPanel);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UILoginPanelComponent>();
            ui.AddComponent<UILoginPanelLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UILoginPanelLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UILoginPanelLogicComponent>();
            logicComponent.OnHide();
        }
    }
}