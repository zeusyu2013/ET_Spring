namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffContinueComponent))]
    [FriendOfAttribute(typeof(GameBuffContinueComponent))]
    public static partial class GameBuffContinueComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffContinueComponent self)
        {
            self.Time = self.GetParent<GameBuff>().Config.ContinueTime + TimeInfo.Instance.ServerNow();
        }

        [EntitySystem]
        private static void Destroy(this GameBuffContinueComponent self)
        {
            self.Time = 0;
        }

        [EntitySystem]
        private static void Update(this GameBuffContinueComponent self)
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