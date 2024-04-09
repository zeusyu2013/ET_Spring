/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIMain)]
    public class UIMainEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Main, UIName.UIMain);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.Main, UIName.UIMain);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIMainComponent>();
            ui.AddComponent<UIMainLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIMainLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIMainLogicComponent>();
            logicComponent.OnHide();
        }
    }
}