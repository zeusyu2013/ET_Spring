/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
namespace ET.Client
{
    [UIEvent(UIName.UICreateRole)]
    public class UICreateRoleEventHandler : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent)
        {
            GObject gOject = await uiComponent.LoadUIObject(UIPackageName.CreateRole, UIName.UICreateRole);
            if (gOject == null) return null;
            UI ui = uiComponent.CreateUI(UIPackageName.CreateRole, UIName.UICreateRole);
            ui.Component = gOject as GComponent;
            ui.AddComponent<UICreateRoleComponent>();
            ui.AddComponent<UICreateRoleLogicComponent>();
            return ui;
        }

        public override void OnShow(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UICreateRoleLogicComponent>();
            logicComponent.OnShow();
        }

        public override void OnHide(UIComponent uiComponent, UI ui)
        {
            var logicComponent = ui.GetComponent<UICreateRoleLogicComponent>();
            logicComponent.OnHide();
        }
    }
}