using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(GameRoleComponent))]
    [FriendOfAttribute(typeof(ET.Server.GameRoleComponent))]
    [FriendOfAttribute(typeof(ET.Server.GameRole))]
    [FriendOfAttribute(typeof(ET.Server.GameRoleName))]
    public static partial class GameRoleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.GameRoleComponent self)
        {
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Server.GameRoleComponent self)
        {
            self.GameRoles.Clear();
            self.UnitId = 0;
        }

        public static async ETTask<List<GameRoleInfo>> Query(this GameRoleComponent self)
        {
            List<GameRoleInfo> infos = new();

            if (self.GameRoles.Count > 0)
            {
                infos.AddRange(self.GameRoles);
            }
            else
            {
                using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GameRole, self.GetParent<Session>().Id))
                {
                    long playerId = self.GetParent<Session>().GetComponent<SessionPlayerComponent>().Player.Id;

                    List<GameRole> roles = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone())
                            .Query<GameRole>(x => x.PlayerId == playerId);
                    if (roles.Count < 1)
                    {
                        return infos;
                    }

                    foreach (GameRole gameRole in roles)
                    {
                        self.GameRoles.Add(gameRole.ToMessage());
                    }
                    infos.AddRange(self.GameRoles);
                }
            }

            return infos;
        }

        public static async ETTask<int> Create(this GameRoleComponent self, string roleName, int characterType, int raceType)
        {
            if (self.GameRoles.Count >= GlobalDataConfigCategory.Instance.CreateRoleMaxLimit)
            {
                return ErrorCode.ERR_CreateRoleLimit;
            }
            
            Session session = self.GetParent<Session>();
            long playerId = session.GetComponent<SessionPlayerComponent>().Player.Id;

            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GameRole, playerId))
            {
                // 查询重名
                List<GameRoleName> roleNameInfos = await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                        .Query<GameRoleName>(x => x.RoleName.Equals(roleName));

                bool sameName = false;
                foreach (GameRoleName info in roleNameInfos)
                {
                    if (!info.Deleted)
                    {
                        sameName = true;
                    }
                }

                // 重名提示
                if (sameName)
                {
                    return ErrorCode.ERR_CreateRoleNameSame;
                }

                // 开始创角流程
                GameRole gameRole = self.AddChild<GameRole>();
                gameRole.PlayerId = playerId;
                gameRole.RoleName = roleName;
                gameRole.RoleLevel = 1;
                gameRole.RoleModel = "";
                gameRole.CharacterType = characterType;
                gameRole.RaceType = raceType;
                gameRole.Deleted = false;

                await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(gameRole);

                // 存储名字
                GameRoleName gameRoleName = session.Root().GetComponent<RoleNameComponent>().AddChild<GameRoleName>();
                gameRoleName.RoleName = roleName;
                gameRoleName.Deleted = false;
                await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(gameRoleName);
                
                self.GameRoles.Add(gameRole.ToMessage());
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> Delete(this GameRoleComponent self, string roleName)
        {
            Session session = self.GetParent<Session>();
            long playerId = session.GetComponent<SessionPlayerComponent>().Player.Id;

            using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GameRole, playerId))
            {
                List<GameRole> roleInfos =
                        await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone())
                                .Query<GameRole>(x => self.Id == playerId && x.RoleName.Equals(roleName) && !x.Deleted);
                if (roleInfos.Count != 1)
                {
                    return ErrorCode.ERR_DeleteRoleHasNoRole;
                }

                GameRole info = roleInfos[0];
                info.Deleted = true;
                await session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()).Save(info);

                GameRoleInfo roleInfo = self.GameRoles.Find(x => x.RoleName.Equals(roleName));
                if (roleInfo != null)
                {
                    self.GameRoles.Remove(roleInfo);
                }
            }

            return ErrorCode.ERR_Success;
        }
    }
}