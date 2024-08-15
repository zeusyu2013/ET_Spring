using System.Collections.Generic;
using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIBagLogicComponent))]
    [FriendOf(typeof(UIBagLogicComponent))]
    public static partial class UIBagLogicComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIBagLogicComponent self)
        {
            var view = self.GetParent<UI>().GetParent<UIBagComponent>();
            
            view.GCanvas_List_List.SetVirtual();
            view.GCanvas_List_List.onClickItem.Set(BagItemClickEvent);
            view.GCanvas_List_List.itemRenderer = self.BagItemRender;
            
            view.GCanvas_CloseBtn.onClick.Set(() =>
            {
                UIHelper.Remove(self.Root(), UIName.UIBag).Coroutine();
            });
        }
        [EntitySystem]
        private static void Destroy(this UIBagLogicComponent self)
        {
        }
        public static void OnHide(this UIBagLogicComponent self)
        {
        }

        public static void OnShow(this UIBagLogicComponent self)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemInfos"></param>
        public static void SetAllItem(this UIBagLogicComponent self, List<GameItemInfo> itemInfos)
        {
            var view = self.GetParent<UI>().GetParent<UIBagComponent>();

            self.GameItemInfos = itemInfos;
            if (itemInfos == null)
            {
                return;
            }
            view.GCanvas_List_List.numItems = itemInfos.Count;
        }

        /// <summary>
        /// 背包item
        /// </summary>
        /// <param name="context"></param>
        public static void BagItemClickEvent(EventContext context)
        {
            
        }

        public static void BagItemRender(this UIBagLogicComponent self, int index, GObject obj)
        {
            GameItemInfo itemInfo = self.GameItemInfos[index];
            
        }
    }
}