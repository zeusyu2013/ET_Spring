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
            if (!(typeof(IUnitCache).IsAssignableFrom(type)))
            {
                return;
            }

            self.GetComponent<UnitDBSaveComponent>()?.AddChange(type);
        }
    }
}