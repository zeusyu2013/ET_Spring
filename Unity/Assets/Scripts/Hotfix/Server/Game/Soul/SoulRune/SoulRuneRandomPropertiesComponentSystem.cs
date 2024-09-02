namespace ET.Server
{
    [EntitySystemOf(typeof(SoulRuneRandomPropertiesComponent))]
    public static partial class SoulRuneRandomPropertiesComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulRuneRandomPropertiesComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulRuneRandomPropertiesComponent self)
        {
        }

        public static void RandomProperties(this SoulRuneRandomPropertiesComponent self)
        {
            
        }
    }
}