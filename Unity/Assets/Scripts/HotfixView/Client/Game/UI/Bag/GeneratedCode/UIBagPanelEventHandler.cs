/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIBagPanel)]
    public class UIBagPanelEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.Bag, UIName.UIBagPanel);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.Bag, UIName.UIBagPanel);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIBagPanelComponent>();
            ui.AddComponent<UIBagPanelLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIBagPanelLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIBagPanelLogicComponent>();
            logicComponent.OnHide();
        }
    }
}