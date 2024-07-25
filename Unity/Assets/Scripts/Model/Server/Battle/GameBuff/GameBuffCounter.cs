namespace ET.Server
{
    [ComponentOf(typeof(GameBuff))]
    public class GameBuffCounter : Entity, IAwake, IDestroy
    {
        public int Count;
    }
}