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
    }
}