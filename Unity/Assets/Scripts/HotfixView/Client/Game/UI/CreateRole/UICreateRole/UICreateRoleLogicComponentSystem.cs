using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UICreateRoleLogicComponent))]
    [FriendOf(typeof(UICreateRoleLogicComponent))]
    [FriendOfAttribute(typeof(ET.Client.GameRoleInfoComponent))]
    public static partial class UICreateRoleLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UICreateRoleLogicComponent self)
        {
            var view = self.GetParent<UI>().GetComponent<UICreateRoleComponent>();

            view.GCanvas_ConfimBtn.onClick.Set(() =>
            {
                string name = view.GCanvas_NameText.text;
                self.CreateRoleBtnEvent(name).Coroutine();
            });

            view.GCanvas_List.SetVirtual();
            view.GCanvas_List.onClickItem.Set(self.RoleHeadItemClickEvent);
            view.GCanvas_List.itemRenderer = self.RoleHeadItemRenderer;
        }
        [EntitySystem]
        private static void Destroy(this UICreateRoleLogicComponent self)
        {
        }
        public static void OnHide(this UICreateRoleLogicComponent self)
        {
        }

        public static void OnShow(this UICreateRoleLogicComponent self)
        {
            var view = self.GetParent<UI>().GetComponent<UICreateRoleComponent>();
            int count = CreateRoleConfigCategory.Instance.DataList.Count;
            if (count <= 0)
            {
                return;
            }
            view.GCanvas_List.numItems = count;
            view.GCanvas_List.selectedIndex = 0;
            self.CreateRoleConfig = CreateRoleConfigCategory.Instance.DataList[0];
            self.SetRoleInfo(self.CreateRoleConfig);
        }

        private static async ETTask CreateRoleBtnEvent(this UICreateRoleLogicComponent self, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            int err = await LoginHelper.CreateRole(self.Root(), name, (int)self.CreateRoleConfig.Id, (int)self.CreateRoleConfig.RaceFlag);
            if (err != ErrorCode.ERR_Success)
            {
                return;
            }

            long unitId = 0;
            GameRoleInfoComponent gameRoleInfoComponent = self.Root().GetComponent<GameRoleInfoComponent>();
            foreach (var roleInfo in gameRoleInfoComponent.GameRoleInfos)
            {
                if (name != roleInfo.RoleName)
                {
                    continue;
                }

                unitId = roleInfo.UnitId;
            }
            
            // 创建角色成功，接入场景
            await EnterMapHelper.EnterMapAsync(self.Root(), unitId);
            UIHelper.Remove(self.Root(), UIName.UICreateRole).Coroutine();
        }

        private static void RoleHeadItemClickEvent(this UICreateRoleLogicComponent self, EventContext context)
        {
            GButton btn = context.data as GButton;
            int index = (int)btn.data;
            CreateRoleConfig roleConfig = CreateRoleConfigCategory.Instance.DataList[index];
            self.CreateRoleConfig = roleConfig;

            self.SetRoleInfo(roleConfig);
        }

        private static void RoleHeadItemRenderer(this UICreateRoleLogicComponent self, int index, GObject obj)
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
        private static void SetRoleInfo(this UICreateRoleLogicComponent self, CreateRoleConfig roleConfig)
        {
            var view = self.GetParent<UI>().GetComponent<UICreateRoleComponent>();
            view.GCanvas_RaceText.text = roleConfig.RaceFlag.ToString();
            view.GCanvas_CharacterText.text = roleConfig.Id.ToString();
        }
    }
}