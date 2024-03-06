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
            UIGroupSubConfigCategory.Instance.InitSubConfig();
        }
        
        [EntitySystem]
        private static void Destroy(this UIGroupComponent self)
        {
            self.TraceIdList.Clear();
        }
        
        /// <summary>
        /// 打开UIGroup
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId"></param>
        public static async ETTask OpenGroup(this UIGroupComponent self, UIDefine.UIGroupId groupId)
        {
            // 重复打开相同的组，不处理
            if (self.GroupId == groupId)
            {
                return;
            }

            int id = (int)groupId;
            UIGroupConfig groupConfig = UIGroupConfigCategory.Instance.Get(id);
            if (groupConfig == null)
            {
                return;
            }

            // 修正组打开，不关闭当前组
            if (groupConfig.Type != UIGroupType.BaseFixed &&
                groupConfig.Type != UIGroupType.NormalFixed)
            {
                // 先关闭当前组的界面
                self.CloseGroupPanels(id);
            }
    
            self.AddTraceId(groupConfig);
            
            // 打开界面
            await self.OpenGroupPanels(id);
        }
        

        /// <summary>
        /// 界面回朔
        /// </summary>
        /// <param name="self"></param>
        public static void BackTrackingGroup(this UIGroupComponent self)
        {
            int count = self.TraceIdList.Count;
            // 保留一个组，这个组就是Base
            if (count <= 1)
            {
                return;
            }
        
            var groupConfig = self.TraceIdList[count - 1];
            // 移出列表
            self.TraceIdList.RemoveAt(count - 1);
            //  关闭当前组界面
            self.CloseGroupPanels(groupConfig.Id);
            // 打开组界面
            if (groupConfig.Type == UIGroupType.BaseFixed ||
                groupConfig.Type == UIGroupType.NormalFixed)
            {
                // 因为修正界面可能关闭界面, 这里只处理被关闭的界面
                
                
            }
            else 
            {
                // 重新刷新下界面
                self.OpenGroupPanels(self.TraceIdList[self.TraceIdList.Count - 1].Id).Coroutine();
            }
        }
        
        
        /// <summary>
        /// 界面回朔
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupConfig">组配置</param>
        public static void AddTraceId(this UIGroupComponent self, UIGroupConfig groupConfig)
        {
            if (groupConfig.TraceId < 0)
            {
                return;
            }

            int count = self.TraceIdList.Count;
            // 添加默认数据
            if (count <= 0)
            {
                self.TraceIdList.Add(groupConfig);
                return;
            }
            
            // 如果当前打开的是base，那么要替换掉，原baseID, base排最底层
            if (groupConfig.Type == UIGroupType.Base ||
                groupConfig.Type == UIGroupType.GeneralBase)
            {
                self.TraceIdList.Clear();
                self.TraceIdList.Add(groupConfig);
                return;
            }
            // traceId相同做替换
            UIGroupConfig lastData = self.TraceIdList[count - 1];
            if (lastData.TraceId == groupConfig.TraceId)
            {
                self.TraceIdList[count - 1] = groupConfig;
                return;
            }

            int index = self.TraceIdList.FindIndex(data => data == groupConfig);
            if (index == -1)
            {
                self.TraceIdList.Add(groupConfig);
                return;
            }
            // 清除
            self.TraceIdList.RemoveRange(index + 1, count - index - 1);
        }

        /// <summary>
        /// 打开界面组
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId">组Id</param>
        /// <param name="isShowHide"></param>
        public static async ETTask OpenGroupPanels(this UIGroupComponent self, int groupId, bool isShowHide = false)
        {
            var subDataList = UIGroupSubConfigCategory.Instance.GetGroupSubData(groupId);
            if (subDataList == null)
            {
                return;
            }
            
            UIComponent uiComponent = self.Parent as UIComponent;
            self.GroupId = (UIDefine.UIGroupId)groupId;
            foreach (var data in subDataList)
            {
                await uiComponent.CreatePanel(data.PanelName);
            }
            // 界面全加载完后显示界面
            foreach (var data in subDataList)
            {
                UI ui = uiComponent.GetPanel(data.PanelName);
                if (ui == null)
                {
                    continue;
                }
                
                if(isShowHide && ui.IsShowing)
                {
                    
                    continue;
                }
            
                if (data.Args != null)
                {
                    uiComponent.GetComponent<UIExtraDataComponent>().SetUIData(data.PanelName, data.Args);
                }
                
                uiComponent.ShowPanel(data.PanelName);
            }
        }
        
        /// <summary>
        /// 关闭当前界面组
        /// </summary>
        /// <param name="self"></param>
        /// <param name="groupId"></param>
        public static void CloseGroupPanels(this UIGroupComponent self, int groupId)
        {
            if (groupId != (int)self.GroupId)
            {
                return;
            }
            var subDataList = UIGroupSubConfigCategory.Instance.GetGroupSubData((int)groupId);
            if (subDataList == null)
            {
                return;
            }
            UIComponent uiComponent = self.Parent as UIComponent;
            foreach (var data in subDataList)
            {
                uiComponent.HidePanel(data.PanelName).Coroutine();
            }
        }
    }
}
