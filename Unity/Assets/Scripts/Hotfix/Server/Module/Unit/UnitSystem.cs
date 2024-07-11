namespace ET.Server
{
    [EntitySystemOf(typeof(Unit))]
    public static partial class UnitSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Unit self, int configId)
        {
        }

        [EntitySystem]
        private static void GetComponentSys(this Unit self, System.Type type)
        {
            object[] attrs = type.GetCustomAttributes(typeof(UnitCacheEventAttribute), false);
            if (attrs.Length == 0)
            {
                return;
            }
            
            self.GetComponent<UnitDBSaveComponent>()?.AddChange(type);
        }
    }
}