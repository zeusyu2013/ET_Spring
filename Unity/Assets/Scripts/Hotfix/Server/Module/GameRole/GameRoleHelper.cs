namespace ET.Server
{
    [FriendOf(typeof(GameRoleName))]
    public static partial class GameRoleHelper
    {
        public static async ETTask<string> GetRoleName(Scene scene, long unitId)
        {
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            if (dbComponent == null)
            {
                return "";
            }

            GameRoleName gameRoleName = await dbComponent.Query<GameRoleName>(unitId);
            if (gameRoleName == null)
            {
                return "";
            }

            return gameRoleName.RoleName;
        }

        public static async ETTask ModifyRoleName(Scene scene, long unitId, string newName)
        {
            DBComponent dbComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            if (dbComponent == null)
            {
                Log.Error("修改玩家姓名失败，未找到数据库");
                return;
            }

            GameRoleName gameRoleName = await dbComponent.Query<GameRoleName>(unitId);
            if (gameRoleName == null)
            {
                Log.Error($"修改玩家姓名失败，未找到指定unit id：{unitId}");
                return;
            }

            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.DB, unitId))
            {
                gameRoleName.RoleName = newName;
                await dbComponent.Save(gameRoleName);
            }
        }
    }
}