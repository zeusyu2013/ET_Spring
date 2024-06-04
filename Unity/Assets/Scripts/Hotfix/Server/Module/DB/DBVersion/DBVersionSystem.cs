using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(DBVersion))]
    [FriendOf(typeof(DBVersion))]
    public static partial class DBVersionSystem
    {
        [EntitySystem]
        public static void Awake(this DBVersion self, int process, int zone)
        {
            self.Process = process;
            self.Zone = zone;
            
            self.Query().Coroutine();
        }

        public static async ETTask Query(this DBVersion self)
        {
            DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
            if (dbComponent == null)
            {
                Log.Error("未找到DB数据库");
                return;
            }

            List<DBVersion> dbVersions = await dbComponent.Query<DBVersion>(x => x.Process == self.Process && x.Zone == self.Zone);
            if (dbVersions.Count < 1)
            {
                self.DBVersionNumber = 0;
                await self.SyncDBVersion();
                return;
            }

            DBVersion dbVersion = dbVersions[0];
            if (dbVersion == null)
            {
                self.DBVersionNumber = 0;
                await self.SyncDBVersion();
                return;
            }

            self.DBVersionNumber = dbVersion.DBVersionNumber;
            await self.SyncDBVersion();
        }

        public static async ETTask SyncDBVersion(this DBVersion self)
        {
            HashSet<Type> attributes = CodeTypes.Instance.GetTypes(typeof(DBVersionAttribute));
            if (attributes.Count < 1)
            {
                return;
            }

            foreach (Type type in attributes)
            {
                object[] attrs = type.GetCustomAttributes(typeof(DBVersionAttribute), false);
                if (attrs.Length < 1)
                {
                    continue;
                }

                DBVersionAttribute dbVersionAttribute = attrs[0] as DBVersionAttribute;

                int version = (int)dbVersionAttribute.DBVersionEnum;
                if (version > self.DBVersionNumber)
                {
                    //todo:检查服务器与数据库数据是否一致
                    
                    self.DBVersionNumber = version;
                }
            }
            
            DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
            if (dbComponent == null)
            {
                Log.Error("未找到DB数据库");
                return;
            }

            await dbComponent.Save(self);
        }
    }
}