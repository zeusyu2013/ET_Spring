using System.Collections.Generic;

namespace ET.Server
{
    public static class DBCacheHelper
    {
        public static async ETTask<List<byte[]>> GetCache(Scene scene, long unitId)
        {
            Other2DBCache_GetEntities request = Other2DBCache_GetEntities.Create();
            request.UnitId = unitId;
            StartSceneConfig dbCacheConfig = StartSceneConfigCategory.Instance.DBCache;
            DBCache2Other_GetEntities response =
                    (DBCache2Other_GetEntities)await scene.GetComponent<MessageSender>().Call(dbCacheConfig.ActorId, request);
            return response.EntityBytes;
        }

        /// <summary>
        /// 立即存储指定组件
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="unitId"></param>
        /// <param name="entity"></param>
        public static void SaveImmediately(Scene scene, Entity entity)
        {
            Other2DBCache_SaveImmediately request = Other2DBCache_SaveImmediately.Create();
            request.UnitId = entity.Id;
            request.EntityBytes = entity.ToBson();
            StartSceneConfig dbCacheConfig = StartSceneConfigCategory.Instance.DBCache;
            scene.GetComponent<MessageSender>().Send(dbCacheConfig.ActorId, request);
        }
    }
}