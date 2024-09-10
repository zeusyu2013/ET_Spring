using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_GetEntitiesHandler : MessageHandler<Scene, Other2DBCache_GetEntities, DBCache2Other_GetEntities>
    {
        protected override async ETTask Run(Scene scene, Other2DBCache_GetEntities request, DBCache2Other_GetEntities response)
        {
            List<Entity> entities = await scene.GetComponent<DBCacheComponent>().QueryUnitComponents(request.UnitId);
            List<byte[]> entityBytesLis = new();
            foreach (var entity in entities)
            {
                entityBytesLis.Add(entity.ToBson());
            }

            response.EntityBytes = entityBytesLis;
        }
    }
}