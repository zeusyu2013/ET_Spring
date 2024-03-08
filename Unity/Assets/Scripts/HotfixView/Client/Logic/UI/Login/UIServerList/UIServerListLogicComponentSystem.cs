
using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIServerListLogicComponent))]
    [FriendOf(typeof(UIServerListLogicComponent))]
    public static partial class UIServerListLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIServerListLogicComponent self)
        {
            var view = self.GetParent<UI>().GetComponent<UIServerListComponent>();
            
            view.GCanvas_ServerList.SetVirtual();
            view.GCanvas_ServerList.onClickItem.Set(self.ServerItemClickEvent);
            view.GCanvas_ServerList.itemRenderer = self.ServerItemRenderer;
            
            view.GCanvas_DisList.SetVirtual();
            view.GCanvas_DisList.onClickItem.Set(self.DistrcitClickEvent);
            view.GCanvas_DisList.itemRenderer = self.DistrcitItemRenderer;
            
            view.GCanvas_CloseBtn.onClick.Set(() =>
            {
                UIHelper.Remove(self.Root(), UIName.UIServerList);
            });
        }
        
        [EntitySystem]
        private static void Destroy(this UIServerListLogicComponent self)
        {
            self.ServersList = null;
            self.DistrictsList = null;
        }
        public static void OnHide(this UIServerListLogicComponent self)
        {
        }

        public static void OnShow(this UIServerListLogicComponent self)
        {
            object[] args = UIHelper.GetUIData(self.Root(), UIName.UIServerList);
            
            self.GetServerList(args[0] as string).Coroutine();
        }
        
        public static async ETTask GetServerList(this UIServerListLogicComponent self, string account)
        { 
            var mapleComponent = self.Root().GetComponent<MapleComponent>();
            await mapleComponent.PullServers(account);
            var view = self.GetParent<UI>().GetComponent<UIServerListComponent>();
             
            var mapleData = mapleComponent.MapleInfo;
            var info = mapleData.maple_info;

            self.DistrictsList = info.districts;
            view.GCanvas_DisList.numItems = info.districts.Count;

            if (info.districts.Count > 0)
            {
                self.ServersList = info.districts[0].servers;
                view.GCanvas_ServerList.numItems = self.ServersList.Count;
            }
        }
        
        public static void ServerItemClickEvent(this UIServerListLogicComponent self, EventContext context)
        {
            GButton btn = context.data as GButton;
            
            Servers info = btn.data as Servers;
            Servers serverInfo = self.Root().GetComponent<PlayerPrefsComponent>().ServerInfo;
            serverInfo.server_addr = info.server_addr;
            serverInfo.server_id = info.server_id;
            serverInfo.server_port = info.server_port;
            serverInfo.server_name = info.server_name;
            
            self.Root().GetComponent<PlayerPrefsComponent>().ServerInfo = serverInfo;
            
            UIHelper.Remove(self.Root(), UIName.UIServerList);
        }
        
        public static void ServerItemRenderer(this UIServerListLogicComponent self, int index, GObject obj)
        {
            GButton btn = obj as GButton;

            GTextField nameText = btn.GetChild("Name") as GTextField;

            nameText.text = self.ServersList[index].server_name;

            btn.data = self.ServersList[index];
        }


        public static void DistrcitClickEvent(this UIServerListLogicComponent self, EventContext context)
        {
            
        }

        public static void DistrcitItemRenderer(this UIServerListLogicComponent self, int index, GObject obj)
        {
            GButton btn = obj as GButton;

            GTextField nameText = btn.GetChild("Name") as GTextField;
            
            nameText.text = self.DistrictsList[index].district_name;
        }
    }
}