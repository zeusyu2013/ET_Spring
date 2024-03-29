/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UILogin)]
    public class UILoginEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Login, UIName.UILogin);
            if (gOject == null) return null;
            UI ui = uiComponent.AddChild<UI, string, string>(UIPackageName.Login, UIName.UILogin);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UILoginComponent>();
            ui.AddComponent<UILoginLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UILoginLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UILoginLogicComponent>();
            logicComponent.OnHide();
        }
    }
}