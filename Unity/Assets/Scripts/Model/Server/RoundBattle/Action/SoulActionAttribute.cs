namespace ET.Server
{
    public class SoulActionAttribute : BaseAttribute
    {
        public SoulActionType ActionType { get; }

        public SoulActionAttribute(SoulActionType type)
        {
            this.ActionType = type;
        }
    }
}