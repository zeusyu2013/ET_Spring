namespace ET.Server
{
    [EntitySystemOf(typeof(SoulBuff))]
    [FriendOfAttribute(typeof(ET.Server.SoulBuff))]
    public static partial class SoulBuffSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulBuff self, int configId)
        {
            self.ConfigId = configId;
            self.AddComponent<SoulActionComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulBuff self)
        {
            self.ConfigId = default;
            self.Owner = default;
            self.Round = default;
        }

        public static void AddActions(this SoulBuff self)
        {
            foreach (int action in self.Config.AddActions)
            {
                self.Create(action, SoulActionTriggerType.BuffAdd);
            }
        }

        public static void NewRoundActions(this SoulBuff self)
        {
            foreach (int action in self.Config.NewRoundActions)
            {
                self.Create(action, SoulActionTriggerType.BuffNewRound);
            }
        }

        public static void RemoveActions(this SoulBuff self)
        {
            foreach (int action in self.Config.RemoveActions)
            {
                self.Create(action, SoulActionTriggerType.BuffRemove);
            }
        }
    }
}