namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_GetEntitiesHandler : MessageHandler<Scene, Other2DBCache_GetEntities, DBCache2Other_GetEntities>
    {
        protected override async ETTask Run(Scene scene, Other2DBCache_GetEntities request, DBCache2Other_GetEntities response)
        {
            response.EntityBytes = await scene.GetComponent<DBCacheComponent>().QueryUnitComponents(request.UnitId);
        }
    }
}