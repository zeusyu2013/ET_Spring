namespace ET.Server
{
    [GameItemUse(GameItemUseType.GameItemUseType_Buff)]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class GameItemUse_GetBuff : IGameItemUse
    {
        public int Run(GameItem item, long useAmount)
        {
            ItemUseConfig config = ItemUseConfigCategory.Instance.Get(item.ConfigId);

            GameItemUseBuff conf = config.GameItemUseParam as GameItemUseBuff;

            Unit unit = item.GetParent<BagComponent>().GetParent<Unit>();

            bool ret = unit.GetComponent<BuffComponent>().CreateAndAdd(conf.BuffConfigId);
            if (!ret)
            {
                return ErrorCode.ERR_AddBuffFailed;
            }

            return ErrorCode.ERR_Success;
        }
    }
}