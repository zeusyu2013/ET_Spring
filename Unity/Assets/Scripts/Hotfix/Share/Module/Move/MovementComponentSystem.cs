namespace ET
{
    [EntitySystemOf(typeof (MovementComponent))]
    public static partial class MovementComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.MovementComponent self)
        {
        }

        [EntitySystem]
        private static void Update(this ET.MovementComponent self)
        {
            
        }
    }
}