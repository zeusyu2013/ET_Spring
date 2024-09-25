namespace ET.Server
{
    [GameItemUse(GameItemUseType.GameItemUseType_Task)]
    public class GameItemUse_GetTask : IGameItemUse
    {
        public bool Run(GameItem item, long useAmount, ItemUseConfig config)
        {
            Unit unit = item.GetParent<BagComponent>().GetParent<Unit>();
            
            GameItemUseTask conf = config.GameItemUseParam as GameItemUseTask;

            int errorCode = unit.GetComponent<GameTaskComponent>().AcceptTask(conf.TaskConfigId);

            return errorCode == ErrorCode.ERR_Success;
        }
    }
}