namespace ET.Server
{
    public enum CurrencyChangeType
    {
        Inc = 1,
        Dec = 2,
    }
    
    public struct CurrencyChanged
    {
        public Unit Unit;
        public CurrencyType Type;
        public CurrencyChangeType ChangeType;
        public long OldValue;
        public long NewValue;
    }
}