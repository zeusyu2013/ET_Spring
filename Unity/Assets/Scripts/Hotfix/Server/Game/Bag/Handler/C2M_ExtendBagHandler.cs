namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.Server.BagComponent))]
    public class C2M_ExtendBagHandler : MessageLocationHandler<Unit, C2M_ExtendBag, M2C_ExtendBag>
    {
        protected override async ETTask Run(Unit unit, C2M_ExtendBag request, M2C_ExtendBag response)
        {
            // 检查扩容背包道具
            int extendBagItemConfig = GlobalDataConfigCategory.Instance.ExtendBagItemConfig;
            if (extendBagItemConfig < 1)
            {
                response.Error = ErrorCode.ERR_ExtendBagItemConfigError;
                response.Message = "扩容背包道具id异常";
                return;
            }

            bool ret = unit.GetComponent<BagComponent>().RemoveItem(extendBagItemConfig, 1);
            if (!ret)
            {
                response.Error = ErrorCode.ERR_ItemNotEnough;
                response.Message = "扩容背包道具不足";
                return;
            }

            if (unit.GetComponent<BagComponent>().MaxCapacity >= GlobalDataConfigCategory.Instance.BagMaxCapacity)
            {
                response.Error = ErrorCode.ERR_BagCapacityMaxLimit;
                response.Message = "背包扩容上限";
                return;
            }

            unit.GetComponent<BagComponent>().MaxCapacity += GlobalDataConfigCategory.Instance.ExtendBagCapacity;

            response.MaxCapacity = unit.GetComponent<BagComponent>().MaxCapacity;

            await ETTask.CompletedTask;
        }
    }
}