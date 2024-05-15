using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIChooseRoleLogicComponent))]
    [FriendOf(typeof(UIChooseRoleLogicComponent))]
    [FriendOfAttribute(typeof(ET.Client.GameRoleInfoComponent))]
    public static partial class UIChooseRoleLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIChooseRoleLogicComponent self)
        {
            var view = self.GetParent<UI>().GetComponent<UIChooseRoleComponent>();

            view.GCanvas_List.SetVirtual();
            view.GCanvas_List.onClickItem.Set(self.RoleHeadItemClickEvent);
            view.GCanvas_List.itemRenderer = self.RoleHeadItemRenderer;

            view.GCanvas_EnterBtn.onClick.Set(() =>
            {
                EnterMapHelper.EnterMapAsync(self.Root(), self.RoleInfo.UnitId).Coroutine();
            });
            
            view.GCanvas_DeleteBtn.onClick.Set(() =>
            {
                self.DeletaRoleClickEvent().Coroutine();
            });
            
            view.GCanvas_CreateBtn.onClick.Set(() =>
            {
                UIHelper.Create(self.Root(), UIName.UICreateRole).Coroutine();
                UIHelper.Remove(self.Root(), UIName.UIChooseRole).Coroutine();
            });
        }
        [EntitySystem]
        private static void Destroy(this UIChooseRoleLogicComponent self)
        {
        }
        public static void OnHide(this UIChooseRoleLogicComponent self)
        {
        }

        public static void OnShow(this UIChooseRoleLogicComponent self)
        {
           self.ShowRoles().Coroutine();
        }

        private static async ETTask DeletaRoleClickEvent(this UIChooseRoleLogicComponent self)
        {
           await LoginHelper.DeleteRole(self.Root(), self.RoleInfo.RoleName);
           
           self.ShowRoleList();
        }

        private static async ETTask ShowRoles(this UIChooseRoleLogicComponent self)
        {
            await LoginHelper.GetRoleInfos(self.Root());

            self.ShowRoleList();
        }

        private static void ShowRoleList(this UIChooseRoleLogicComponent self)
        {
            var view = self.GetParent<UI>().GetComponent<UIChooseRoleComponent>();
            GameRoleInfoComponent gameRoleInfoComponent = self.Root().GetComponent<GameRoleInfoComponent>();

            int count = gameRoleInfoComponent.GameRoleInfos.Count;
            if (count <= 0)
            {
                UIHelper.Create(self.Root(), UIName.UICreateRole).Coroutine();
                UIHelper.Remove(self.Root(), UIName.UIChooseRole).Coroutine();
                return;
            }

            object[] args =  UIHelper.GetUIData(self.Root(), UIName.UIChooseRole);
            int chooseIndex = 0;
            if (args != null && args.Length == 1)
            {
                string roleName = (string)args[0];
                int index = gameRoleInfoComponent.GameRoleInfos.FindIndex(data => data.RoleName == roleName);
                if (index != -1)
                {
                    chooseIndex = index;
                }
            }
          
            view.GCanvas_List.numItems = count;
            view.GCanvas_List.selectedIndex = chooseIndex;
            self.RoleInfo = gameRoleInfoComponent.GameRoleInfos[chooseIndex];
            self.SetRoleInfo(self.RoleInfo);
        }

        private static void RoleHeadItemClickEvent(this UIChooseRoleLogicComponent self, EventContext context)
        {
            GButton btn = context.data as GButton;
            int index = (int)btn.data;
            GameRoleInfoComponent gameRoleInfoComponent = self.Root().GetComponent<GameRoleInfoComponent>();
            
            self.RoleInfo = gameRoleInfoComponent.GameRoleInfos[index];

            self.SetRoleInfo(self.RoleInfo);
        }

        private static void RoleHeadItemRenderer(this UIChooseRoleLogicComponent self, int index, GObject obj)
        {
            GButton btn = obj as GButton;
            GLoader icon = btn.GetChild("Icon") as GLoader;

            CreateRoleConfig roleConfig = CreateRoleConfigCategory.Instance.DataList[index];
            obj.data = index;


            icon.url = $"ui://CreateRole/{(int)roleConfig.Id}";
        }

        /// <summary>
        /// roleConfig
        /// </summary>
        /// <param name="self"></param>
        /// <param name="roleConfig">觉色基础配置</param>
        private static void SetRoleInfo(this UIChooseRoleLogicComponent self, GameRoleInfo roleInfo)
        {
            var view = self.GetParent<UI>().GetComponent<UIChooseRoleComponent>();
            view.GCanvas_RaceText.text = roleInfo.RaceType.ToString();
            view.GCanvas_CharacterText.text = roleInfo.CharacterType.ToString();
        }
    }
}