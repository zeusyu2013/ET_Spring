namespace ET.Client
{
    public static class UIHelper
    {
        [EnableAccessEntiyChild]
        public static async ETTask Create(Entity scene, string panelName, bool isShow = true)
        {
           UIComponent uiComponent = scene.GetComponent<UIComponent>();
           await uiComponent.CreatePanel(panelName);
           if (isShow)
           {
               uiComponent.ShowPanel(panelName);
           }
        }

        [EnableAccessEntiyChild]
        public static void Show(Entity scene, string panelName)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            uiComponent.ShowPanel(panelName);
        }

        [EnableAccessEntiyChild]
        public static void Hide(Entity scene, string panelName)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            uiComponent.HidePanel(panelName).Coroutine();
        }

        [EnableAccessEntiyChild]
        public static void Remove(Entity scene, string panelName)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            uiComponent.RemovePanel(panelName).Coroutine();
        }

        [EnableAccessEntiyChild]
        public static void OpenGroup(Entity scene, UIDefine.UIGroupId groupId)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIGroupComponent groupComponent = uiComponent.GetComponent<UIGroupComponent>();
            groupComponent.OpenGroup(groupId).Coroutine();
        }

        [EnableAccessEntiyChild]
        public static UIDefine.UIGroupId GetGroupId(Entity scene)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIGroupComponent groupComponent = uiComponent.GetComponent<UIGroupComponent>();
            return groupComponent.GroupId;
        }

        [EnableAccessEntiyChild]
        public static void SetUIData(Entity scene, string key, params object[] args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIExtraDataComponent groupComponent = uiComponent.GetComponent<UIExtraDataComponent>();
            groupComponent.SetUIData(key, args);
        }
        
        [EnableAccessEntiyChild]
        public static object[] GetUIData(Entity scene, string key)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIExtraDataComponent groupComponent = uiComponent.GetComponent<UIExtraDataComponent>();
            return groupComponent.GetUIData(key);
        }
    }
}