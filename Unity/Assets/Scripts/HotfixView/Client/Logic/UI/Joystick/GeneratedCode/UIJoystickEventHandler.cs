/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIJoystick)]
    public class UIJoystickEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Joystick, UIName.UIJoystick);
            if (gOject == null) return null;
            UI ui = uiComponent.AddChild<UI, string, string>(UIPackageName.Joystick, UIName.UIJoystick);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIJoystickComponent>();
            ui.AddComponent<UIJoystickLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIJoystickLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIJoystickLogicComponent>();
            logicComponent.OnHide();
        }
    }
}