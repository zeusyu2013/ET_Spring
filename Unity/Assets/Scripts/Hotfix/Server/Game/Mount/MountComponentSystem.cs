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

        public static int ActivationMount(this MountComponent self, int mountConfigId)
        {
            if (self.Mounts.Contains(mountConfigId))
            {
                return ErrorCode.ERR_HasMount;
            }

            MountConfig mountConfig = MountConfigCategory.Instance.Get(mountConfigId);
            if (mountConfig == null)
            {
                return ErrorCode.ERR_MountConfigError;
            }

            bool ret = self.GetParent<Unit>().GetComponent<BagComponent>().RemoveItem(mountConfig.ActivationItem, 1);
            if (!ret)
            {
                return ErrorCode.ERR_ItemNotEnough;
            }

            self.Mounts.Add(mountConfigId);

            EventSystem.Instance.Publish(self.Root(), new GetNewMount()
            {
                Unit = self.GetParent<Unit>(),
                MountConfigId = mountConfigId,
                TotalMountCount = self.Mounts.Count
            });

            return ErrorCode.ERR_Success;
        }

        public static void Ride(this MountComponent self, int mountConfigId)
        {
            if (!self.Mounts.Contains(mountConfigId))
            {
                return;
            }

            EventSystem.Instance.Publish(self.Root(), new MountChanged()
            {
                Unit = self.GetParent<Unit>(),
                OldMount = self.MountConfigId,
                NewMount = mountConfigId
            });

            self.MountConfigId = mountConfigId;
        }

        public static void Down(this MountComponent self)
        {
            EventSystem.Instance.Publish(self.Root(), new MountChanged()
            {
                Unit = self.GetParent<Unit>(),
                OldMount = self.MountConfigId,
                NewMount = 0
            });
            
            self.MountConfigId = 0;
        }
    }
}