namespace ET.Client
{
    public static partial class UIHelper
    {
        [EnableAccessEntiyChild]
        public static async ETTask Create(Entity scene, string uiName, bool isShow = true)
        {
           UIComponent uiComponent = scene.GetComponent<UIComponent>();
           await uiComponent.CreatePanel(uiName);
           if (isShow)
           {
               uiComponent.ShowPanel(uiName);
           }
        }

        [EnableAccessEntiyChild]
        public static void Show(Entity scene, string uiName)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            uiComponent.ShowPanel(uiName);
        }

        [EnableAccessEntiyChild]
        public static async ETTask Hide(Entity scene, string uiName)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            await uiComponent.HidePanel(uiName);
        }

        [EnableAccessEntiyChild]
        public static async ETTask Remove(Entity scene, string uiName)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            await uiComponent.RemovePanel(uiName);
        }

        [EnableAccessEntiyChild]
        public static async ETTask OpenGroup(Entity scene, UIDefine.UIGroupId groupId)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIGroupComponent groupComponent = uiComponent.GetComponent<UIGroupComponent>();
            await groupComponent.OpenGroup(groupId);
        }

        [EnableAccessEntiyChild]
        public static UIDefine.UIGroupId GetGroupId(Entity scene)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            UIGroupComponent groupComponent = uiComponent.GetComponent<UIGroupComponent>();
            return groupComponent.GroupId;
        }

        [EnableAccessEntiyChild]
        public static T GetUIComponent<T>(Entity scene, string uiName) where T : Entity
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            var ui = uiComponent.GetPanel(uiName);
            if (ui == null)
            {
                return null;
            }
            
            return ui.GetComponent<T>();
        }

        [EnableAccessEntiyChild]
        public static T GetUIComponent<T>(UI ui) where T : Entity
        {
            if (ui == null)
            {
                return null;
            }

            return ui.GetComponent<T>();
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