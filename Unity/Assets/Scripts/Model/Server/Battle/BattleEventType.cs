namespace ET.Server
{
    public struct OnDamageEvent
    {
        public Unit Caster;
        public Unit Target;
        public long DamageValue;
    }

    public struct OnDeadEvent
    {
        public Unit Caster;
        public Unit Target;
    }
}