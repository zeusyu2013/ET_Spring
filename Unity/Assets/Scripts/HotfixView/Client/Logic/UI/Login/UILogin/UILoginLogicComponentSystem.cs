
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
            
            view.GCanvas_AccountText.text = self.Root().GetComponent<PlayerPrefsComponent>().Account;
            view.GCanvas_PasswordText.text = self.Root().GetComponent<PlayerPrefsComponent>().Passward;
            
            view.GCanvas_LoginBtn.onClick.Set(()=>
            {
                string account = view.GCanvas_AccountText.text;
                string passward = view.GCanvas_PasswordText.text;

                if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(passward))
                {
                    Log.Info("请输入账号或者密码");
                    return;
                }

                view.GCanvas_LoginCtrl.selectedIndex = 1;
                Servers serverInfo = self.Root().GetComponent<PlayerPrefsComponent>().ServerInfo;
			
                if (string.IsNullOrEmpty(serverInfo.server_name))
                {
                    view.GCanvas_ServerName.text = "点击选择服务器。。。";
                }
                else
                {
                    view.GCanvas_ServerName.text = serverInfo.server_name;
                    self.Root().GetComponent<PlayerPrefsComponent>().Account = account;
                    self.Root().GetComponent<PlayerPrefsComponent>().Passward = passward;
                }

            });
            
            view.GCanvas_ServerNameBg.onClick.Set(() =>
            {
                UIHelper.SetUIData(self.Root(), UIName.UIServerList, view.GCanvas_AccountText.text);
                UIHelper.Create(self.Root(), UIName.UIServerList).Coroutine();
            });
            
            view.GCanvas_SelectServerBtn.onClick.Set(() =>
            {
                Servers serverInfo = self.Root().GetComponent<PlayerPrefsComponent>().ServerInfo;
                Log.Info(serverInfo.server_name);
                // 没有服务器名字的时候，重新选择服务器
                if (string.IsNullOrEmpty(serverInfo.server_name))
                {
                    UIHelper.SetUIData(self.Root(), UIName.UIServerList, view.GCanvas_AccountText.text);
                    UIHelper.Create(self.Root(), UIName.UIServerList).Coroutine();
                }
                else
                {         
                    LoginHelper.Login(
                            view.Root(), 
                            view.GCanvas_AccountText.text, 
                            view.GCanvas_PasswordText.text,
                            serverInfo.server_addr,
                            serverInfo.server_port).Coroutine();
                }
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
    }
}