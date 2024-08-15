/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIBag)]
    public class UIBagEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Bag, UIName.UIBag);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.Bag, UIName.UIBag);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIBagComponent>();
            ui.AddComponent<UIBagLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIBagLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIBagLogicComponent>();
            logicComponent.OnHide();
        }
    }
}