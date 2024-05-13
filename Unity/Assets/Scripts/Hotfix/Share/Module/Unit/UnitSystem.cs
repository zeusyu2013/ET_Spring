namespace ET
{
    [EntitySystemOf(typeof(Unit))]
    public static partial class UnitSystem
    {
        [EntitySystem]
        private static void Awake(this Unit self, int configId)
        {
            self.ConfigId = configId;
        }
        
        [EntitySystem]
        private static void GetComponentSys(this Unit self, System.Type type)
        {

        }

        public static UnitConfig Config(this Unit self)
        {
            return UnitConfigCategory.Instance.Get(self.ConfigId);
        }
        
        public static UnitType Type(this Unit self)
        {
            return (UnitType)self.Config().Type;
        }
    }
}