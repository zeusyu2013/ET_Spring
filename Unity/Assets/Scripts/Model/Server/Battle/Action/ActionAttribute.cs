namespace ET.Server
{
    public class ActionAttribute : BaseAttribute
    {
        public ActionType ActionType { get; }

        public ActionAttribute(ActionType type)
        {
            this.ActionType = type;
        }
    }
}