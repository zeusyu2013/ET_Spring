/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UIChooseRole)]
    public class UIChooseRoleEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.CreateRole, UIName.UIChooseRole);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.CreateRole, UIName.UIChooseRole);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UIChooseRoleComponent>();
            ui.AddComponent<UIChooseRoleLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIChooseRoleLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UIChooseRoleLogicComponent>();
            logicComponent.OnHide();
        }
    }
}