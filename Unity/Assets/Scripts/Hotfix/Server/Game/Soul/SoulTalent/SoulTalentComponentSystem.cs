namespace ET.Server
{
    [EntitySystemOf(typeof(SoulTalentComponent))]
    [FriendOfAttribute(typeof(ET.Server.Soul))]
    [FriendOfAttribute(typeof(ET.Server.SoulTalentComponent))]
    public static partial class SoulTalentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulTalentComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulTalentComponent self)
        {
        }

        public static void Add(this SoulTalentComponent self, int configId)
        {
            if (self.SoulTalents.Contains(configId))
            {
                return;
            }

            Soul soul = self.GetParent<Soul>();

            SoulTalentConfig config = SoulTalentConfigCategory.Instance.Get(soul.ConfigId);
            if (config == null)
            {
                return;
            }
        }
    }
}