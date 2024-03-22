namespace ET
{
    [ComponentOf(typeof(GameBuff))]
    public class GameBuffCounter : Entity, IAwake<int>, IDestroy
    {
        public int Count;
    }
}