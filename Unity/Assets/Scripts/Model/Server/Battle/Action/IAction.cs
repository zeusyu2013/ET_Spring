namespace ET.Server
{
    public interface IAction
    {
        void Run(Action action, ActionType type);
    }
}