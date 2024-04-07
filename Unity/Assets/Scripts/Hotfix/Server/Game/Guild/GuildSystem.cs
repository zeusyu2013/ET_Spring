namespace ET.Server
{
    [EntitySystemOf(typeof(Guild))]
    public static partial class GuildSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.Guild self)
        {
        }
    }
}