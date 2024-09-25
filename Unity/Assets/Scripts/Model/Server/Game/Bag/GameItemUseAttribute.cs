namespace ET.Server
{
    public class GameItemUseAttribute : BaseAttribute
    {
        public GameItemUseType Type { get; }

        public GameItemUseAttribute(GameItemUseType type)
        {
            this.Type = type;
        }
    }
}