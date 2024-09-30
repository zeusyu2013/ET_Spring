namespace ET.Server
{
    [EntitySystemOf(typeof(BattleProgressComponent))]
    [FriendOfAttribute(typeof(ET.Server.BattleProgressComponent))]
    public static partial class BattleProgressComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BattleProgressComponent self)
        {
            self.Progress = 0;
            self.TotalProgress = GlobalDataConfigCategory.Instance.BattleTotalProgress;
            self.StartTime = TimeInfo.Instance.ServerNow();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BattleProgressComponent self)
        {
            self.Progress = default;
            self.TotalProgress = default;
            self.StartTime = default;
        }

        public static void Progress(this BattleProgressComponent self)
        {
            int battleSpeed = self.GetParent<Unit>().GetInt(GamePropertyType.GP_BattleSpeed);
            if (battleSpeed < 1)
            {
                return;
            }

            self.Progress += battleSpeed;

            if (self.Progress >= self.TotalProgress)
            {
                EventSystem.Instance.Publish(self.Scene(), new ProgressComplete() { Unit = self.GetParent<Unit>() });
            }
        }

        public static void Reset(this BattleProgressComponent self)
        {
            self.Progress = 0;
            self.StartTime = TimeInfo.Instance.ServerNow();
        }
    }
}