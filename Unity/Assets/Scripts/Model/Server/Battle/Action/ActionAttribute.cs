namespace ET.Server
{
    public class ActionAttribute : BaseAttribute
    {
        public int ActionType { get; }

        public ActionAttribute(int type)
        {
            this.ActionType = type;
        }
    }
}