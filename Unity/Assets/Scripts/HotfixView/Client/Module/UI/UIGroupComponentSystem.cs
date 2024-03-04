namespace ET.Client
{
    [EntitySystemOf(typeof(UIGroupComponent))]
    [FriendOf(typeof(UIGroupComponent))]
    public static partial class UIGroupComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIGroupComponent self)
        {
            // 初始化
            //UIGroupSubConfigCategory.Instance.InitSubConfig();
        }
        
        [EntitySystem]
        private static void Destroy(this UIGroupComponent self)
        {
            self.IdStack.Clear();
        }

        /// <summary>
        /// 打开UIGroup
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId"></param>
        public static async ETTask OpenGroup(this UIGroupComponent self, UIDefine.GroupId groupId)
        {
            // 重复打开相同的组，不处理
            if (self.GroupId == groupId)
            {
                return;
            }

            int id = (int)groupId;
            // UIGroupConfig groupConfig = UIGroupConfigCategory.Instance.Get(id);
            // if (groupConfig == null)
            // {
            //     return;
            // }
            
            // 先关闭当前组的界面
            self.CloseGroup(self.GroupId);
            
            // 打开界面
            await self.OpenGroupPanels(groupId);
            
        }

        /// <summary>
        /// 关闭组
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId">组Id</param>
        public static void CloseGroup(this UIGroupComponent self, UIDefine.GroupId groupId)
        {
            self.CloseGroupPanels(groupId);
        }

        /// <summary>
        /// 跟句租配置打开界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId">组Id</param>
        public static async ETTask OpenGroupPanels(this UIGroupComponent self, UIDefine.GroupId groupId)
        {
            // var subDataList = UIGroupSubConfigCategory.Instance.GetGroupSubData((int)groupId);
            // if (subDataList == null)
            // {
            //     return;
            // }
            //
            // UIComponent uiComponent = self.Parent as UIComponent;
            // self.GroupId = groupId;
            // foreach (var data in subDataList)
            // {
            //     await uiComponent.CreatePanel(data.PanelName);
            // }
            // // 界面全加载完后显示界面
            // foreach (var data in subDataList)
            // {
            //     UI ui = uiComponent.GetPanel(data.PanelName);
            //     if (ui == null)
            //     {
            //         continue;
            //     }
            //
            //     if (data.Args != null)
            //     {
            //         uiComponent.GetComponent<UIExtraDataComponent>().SetUIData(data.PanelName, data.Args);
            //     }
            //     
            //     uiComponent.ShowPanel(data.PanelName);
            // }
        }
        
        /// <summary>
        /// 关闭当前组界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId"></param>
        public static void CloseGroupPanels(this UIGroupComponent self, UIDefine.GroupId groupId)
        {
            if (groupId != self.GroupId)
            {
                return;
            }
            // var subDataList = UIGroupSubConfigCategory.Instance.GetGroupSubData((int)groupId);
            // if (subDataList == null)
            // {
            //     return;
            // }
            // UIComponent uiComponent = self.Parent as UIComponent;
            // foreach (var data in subDataList)
            // {
            //     uiComponent.HidePanel(data.PanelName).Coroutine();
            // }
        }

        /// <summary>
        /// 界面回朔
        /// </summary>
        /// <param name="self"></param>
        public static void BackTracking(this UIGroupComponent self)
        {
            
        }
        
    }
}
