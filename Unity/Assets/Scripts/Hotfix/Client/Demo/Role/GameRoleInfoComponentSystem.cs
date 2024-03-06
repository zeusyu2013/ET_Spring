namespace ET.Client
{
    [EntitySystemOf(typeof(GameRoleInfoComponent))]
    [FriendOfAttribute(typeof(ET.Client.GameRoleInfoComponent))]
    public static partial class GameRoleInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.GameRoleInfoComponent self)
        {
        }

        public static void ClearInfos(this GameRoleInfoComponent self)
        {
            self.GameRoleInfos.Clear();
        }

        public static void AddGameRoleInfo(this GameRoleInfoComponent self, GameRoleInfo info)
        {
            self.GameRoleInfos.Add(info);
        }
    }
}