namespace ET
{
    [EntitySystemOf(typeof(GameBuffContinueComponent))]
    [FriendOfAttribute(typeof(ET.GameBuffContinueComponent))]
    public static partial class GameBuffContinueComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.GameBuffContinueComponent self)
        {
            self.Time = self.GetParent<GameBuff>().Config.ContinueTime + TimeInfo.Instance.ServerNow();
        }

        [EntitySystem]
        private static void Destroy(this ET.GameBuffContinueComponent self)
        {
            self.Time = 0;
        }

        [EntitySystem]
        private static void Update(this ET.GameBuffContinueComponent self)
        {
            if (self.Time < TimeInfo.Instance.ServerNow())
            {
                return;
            }

            if (self.IsDisposed)
            {
                return;
            }
            
            self.GetParent<GameBuff>()?.Dispose();
        }
    }
}