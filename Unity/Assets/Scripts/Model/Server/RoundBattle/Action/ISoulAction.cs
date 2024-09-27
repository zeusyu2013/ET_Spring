namespace ET.Server
{
    public interface ISoulAction
    {
        void Run(SoulAction soulAction, SoulActionTriggerType type);
    }
}