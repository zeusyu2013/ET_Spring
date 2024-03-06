/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

namespace ET.Client
{
    [EntitySystemOf(typeof(UILoginLogicComponent))]
    [FriendOf(typeof(UILoginLogicComponent))]
    public static partial class UILoginLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILoginLogicComponent self)
        {
            UILoginComponent view = self.GetParent<UI>().GetComponent<UILoginComponent>();
            
            view.GLoginBtn.onClick.Set(()=>
            {
                LoginHelper.Login(
                    view.Root(), 
                    view.GAccountText.text, 
                    view.GPasswordText.text).Coroutine();
            });
            
            view.GEnterBtn.onClick.Set(() =>
            {
                self.EnterMap().Coroutine();
            });
            
        }
        [EntitySystem]
        private static void Destroy(this UILoginLogicComponent self)
        {
        }
        public static void OnHide(this UILoginLogicComponent self)
        {
        }

        public static void OnShow(this UILoginLogicComponent self)
        {
         
            
        }
        
        public static async ETTask EnterMap(this UILoginLogicComponent self)
        {
            Scene root = self.Root();
            await EnterMapHelper.EnterMapAsync(root);
            UIHelper.Remove(root, UIName.UILogin);
        }
    }
}