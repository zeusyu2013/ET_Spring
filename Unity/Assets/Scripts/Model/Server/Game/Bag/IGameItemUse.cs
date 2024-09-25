namespace ET.Server
{
    public interface IGameItemUse
    {
        bool Run(GameItem item, long useAmount, ItemUseConfig config);
    }
}