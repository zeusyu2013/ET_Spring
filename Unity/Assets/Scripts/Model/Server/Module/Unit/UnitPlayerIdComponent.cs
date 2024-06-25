namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class UnitPlayerIdComponent : Entity, IAwake, ITransfer
    {
        public long PlayerId;

        public string PlayerIdSting;
    }
}