namespace ET.Server
{
    [GameItemUse(GameItemUseType.GameItemUseType_Buff)]
    public class GameItemUse_GetBuff : IGameItemUse
    {
        public bool Run(GameItem item, long useAmount, ItemUseConfig config)
        {
            GameItemUseBuff conf = config.GameItemUseParam as GameItemUseBuff;

            Unit unit = item.GetParent<BagComponent>().GetParent<Unit>();

            bool ret = unit.GetComponent<BuffComponent>().CreateAndAdd(conf.BuffConfigId);

            return ret;
        }
    }
}