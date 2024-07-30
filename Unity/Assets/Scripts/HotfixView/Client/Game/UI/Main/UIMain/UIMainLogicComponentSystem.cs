namespace ET.Client
{
    [EntitySystemOf(typeof(UIMainLogicComponent))]
    [FriendOf(typeof(UIMainLogicComponent))]
    public static partial class UIMainLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainLogicComponent self)
        {
            UIMainComponent view = self.GetParent<UI>().GetComponent<UIMainComponent>();
            view.GCanvas_Test1.onClick.Set(() =>
            {
                C2M_GetAllItems c2MGetAllItems = C2M_GetAllItems.Create();
                self.Root().GetComponent<ClientSenderComponent>().Call(c2MGetAllItems).Coroutine();
            });
            view.GCanvas_Test2.onClick.Set(() =>
            {
                C2M_GetAllCurrencies c2MGetAllCurrencies = C2M_GetAllCurrencies.Create();
                self.Root().GetComponent<ClientSenderComponent>().Call(c2MGetAllCurrencies).Coroutine();
            });
            view.GCanvas_Test3.onClick.Set(() =>
            {
                C2M_GetOfflineIncome c2MGetOfflineIncome = C2M_GetOfflineIncome.Create();
                self.Root().GetComponent<ClientSenderComponent>().Call(c2MGetOfflineIncome).Coroutine();
            });
            view.GCanvas_Test4.onClick.Set(() =>
            {
                ClientCastHelper.CastSkill(self.Root(), 110001).Coroutine();
            });
        }

        [EntitySystem]
        private static void Destroy(this UIMainLogicComponent self)
        {
        }

        public static void OnHide(this UIMainLogicComponent self)
        {
        }

        public static void OnShow(this UIMainLogicComponent self)
        {
        }

        public static void ShowPing(this UIMainLogicComponent self, long ping)
        {
            UIMainComponent view = self.GetParent<UI>().GetComponent<UIMainComponent>();
            view.GCanvas_PingText.text = ping.ToString();
        }
    }
}