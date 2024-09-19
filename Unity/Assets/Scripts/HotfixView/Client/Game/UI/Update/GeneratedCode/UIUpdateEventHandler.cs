/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIUpdate)]
    public class UIUpdateEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Update, UIName.UIUpdate);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.Update, UIName.UIUpdate);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIUpdateComponent>();
            ui.AddComponent<UIUpdateLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIUpdateLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIUpdateLogicComponent>();
            logicComponent.OnHide();
        }
    }
}