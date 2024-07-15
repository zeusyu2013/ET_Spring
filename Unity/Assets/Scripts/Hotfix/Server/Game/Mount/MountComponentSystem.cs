namespace ET.Server
{
    [EntitySystemOf(typeof(MountComponent))]
    [FriendOfAttribute(typeof(ET.Server.MountComponent))]
    public static partial class MountComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.MountComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.MountComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.MountComponent self)
        {
        }

        public static void ActivationMount(this MountComponent self, int mountConfigId)
        {
            if (self.Mounts.Contains(mountConfigId))
            {
                return;
            }

            MountConfig mountConfig = MountConfigCategory.Instance.Get(mountConfigId);
            if (mountConfig == null)
            {
                return;
            }

            self.Mounts.Add(mountConfigId);
        }
    }
}