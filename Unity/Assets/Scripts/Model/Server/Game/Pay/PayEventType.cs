namespace ET.Server
{
    public struct PayAmountChanged
    {
        public Unit Unit;
        public long OldAmount;
        public long NewAmount;
    }
}