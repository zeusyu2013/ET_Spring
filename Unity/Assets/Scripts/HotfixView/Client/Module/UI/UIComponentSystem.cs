using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof (UIComponent))]
    [FriendOf(typeof(UIComponent))]
    public static partial class UIComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIComponent self)
        {
            // 添加必要组件
            self.AddComponent<UILayerComponent>();
            self.AddComponent<UIPackageComponent>();
            self.AddComponent<UIGroupComponent>();
            self.AddComponent<UIExtraDataComponent>();
            // 
            GRoot.inst.SetContentScaleFactor(1280, 720, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
            
        }

        public static async ETTask CreatePanel(this UIComponent self, string panelName)
        {
            // 如果界面存在就不创建爱了
            if(self.HasPanel(panelName))
            {
                return;
            }
         
            //没有配置就不加载
            UIConfig config = UIConfigCategory.Instance.GetConfigByName(panelName);
            if (config == null)
            {
                return;
            }
            
            UIEventComponent.Instance.UIEvents.TryGetValue(panelName, out var uiEvent);
            if (uiEvent == null)
            {
                return;
            }
            // 创建UI，加载脚本
            UI ui = await uiEvent.OnCreate(self);
            self.UIs.Add(panelName, ui);
            ui.Layer = config.Layer;
        }

        /// <summary>
        /// 界面显示
        /// </summary>
        /// <param name="self"></param>
        /// <param name="panelName">界面名字</param>
        /// <returns></returns>
        public static void ShowPanel(this UIComponent self, string panelName)
        {
            // 如果没找到就不显示
            var ui = self.GetPanel(panelName);
            if (ui == null)
            {
                return;
            }
            
            if (!ui.Component.onStage)
            {
                self.AddOnStage(ui);
            }
            
            ui.IsShowing = true;
            UIEventComponent.Instance.UIEvents[panelName].OnShow(self, ui);
            ui.GetComponent<UIRedComponent>().ShowRedPoint();
            // 出场动画
            ui.GetComponent<UITweenComponent>().PlayEnterTween().Coroutine();
        }

        public static async ETTask HidePanel(this UIComponent self, string panelName)
        {
            var ui = self.GetPanel(panelName);
            if (ui == null)
            {
                return;
            }

            ui.IsShowing = false;
            UIEventComponent.Instance.UIEvents[panelName].OnHide(self, ui);
            self.GetComponent<UIExtraDataComponent>().ClearUIData(panelName);
            
            await self.RealHide(panelName);
        }

        /// <summary>
        /// 真实隐藏界面
        /// </summary>
        /// <param name="self"></param>
        /// <param name="panelName"></param>
        public static async ETTask RealHide(this UIComponent self, string panelName)
        {
            var ui = self.GetPanel(panelName);
            if (ui == null)
            {
                return;
            }
            // 增加退场动画 退场动画结束后将界面隐藏
            await ui.GetComponent<UITweenComponent>().PlayExistTween();
            
            ui.Component.RemoveFromParent();
        }

        public static async ETTask RemovePanel(this UIComponent self, string panelName)
        {
            var ui = self.GetPanel(panelName);
            if (ui == null)
            {
                return;
            }
            await self.HidePanel(panelName);
            
            self.GetComponent<UIPackageComponent>().RemovePackage(panelName);
            self.UIs.Remove(panelName);
            self.RemoveChild(ui.Id);
        }

        /// <summary>
        /// 获取界面
        /// </summary>
        /// <param name="self">组件</param>
        /// <param name="panelName">界面名字</param>
        /// <returns></returns>
        public static UI GetPanel(this UIComponent self, string panelName)
        {
            self.UIs.TryGetValue(panelName, out var ui);
            return ui;
        }

        /// <summary>
        /// 是否存在界面
        /// </summary>
        /// <param name="self">组件</param>
        /// <param name="panelName">界面名字</param>
        /// <returns></returns>
        public static bool HasPanel(this UIComponent self, string panelName)
        {
            return self.UIs.ContainsKey(panelName);
        }
        
        /// <summary>
        /// 加载界面组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="packageName">包名</param>
        /// <param name="panelName">界面名</param>
        /// <returns></returns>
        public static async ETTask<GObject> LoadUIObject(this UIComponent self, string packageName, string panelName)
        {
            await self.GetComponent<UIPackageComponent>().AddPackage(packageName);
            GObject gObject = UIPackage.CreateObject(packageName, panelName);
            return gObject;
        }

        public static void AddOnStage(this UIComponent self, UI ui)
        {
            var layerComponent = self.GetComponent<UILayerComponent>().GetLayerComponet(ui.Layer);
            layerComponent.AddChild(ui.Component);
        }
    }
}