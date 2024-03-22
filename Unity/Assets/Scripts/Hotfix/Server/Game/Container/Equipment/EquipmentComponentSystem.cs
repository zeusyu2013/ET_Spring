namespace ET.Server
{
    [EntitySystemOf(typeof(EquipmentComponent))]
    public static partial class EquipmentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this EquipmentComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this EquipmentComponent self)
        {
        }

        public static void Equip(this EquipmentComponent self, GameItem equipment)
        {
            if (equipment == null || equipment.IsDisposed)
            {
                return;
            }
            
            
        }
    }
}