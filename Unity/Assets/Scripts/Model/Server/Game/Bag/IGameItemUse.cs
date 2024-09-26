namespace ET.Server
{
    public interface IGameItemUse
    {
        int Run(GameItem item, long useAmount);
    }
}