namespace ET.Server
{
    [EntitySystemOf(typeof(RoleNameComponent))]
    public static partial class RoleNameComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.RoleNameComponent self)
        {

        }
    }
}

