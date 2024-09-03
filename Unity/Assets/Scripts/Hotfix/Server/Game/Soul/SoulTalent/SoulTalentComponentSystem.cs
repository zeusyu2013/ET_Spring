namespace ET.Server
{
    [EntitySystemOf(typeof(SoulTalentComponent))]
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
    }
}