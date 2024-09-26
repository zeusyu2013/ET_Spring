namespace ET.Server
{
    [GameItemUse(GameItemUseType.GameItemUseType_Task)]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class GameItemUse_GetTask : IGameItemUse
    {
        public int Run(GameItem item, long useAmount)
        {
            ItemUseConfig config = ItemUseConfigCategory.Instance.Get(item.ConfigId);

            Unit unit = item.GetParent<BagComponent>().GetParent<Unit>();

            GameItemUseTask conf = config.GameItemUseParam as GameItemUseTask;

            int errorCode = unit.GetComponent<GameTaskComponent>().AcceptTask(conf.TaskConfigId);

            return errorCode;
        }
    }
}