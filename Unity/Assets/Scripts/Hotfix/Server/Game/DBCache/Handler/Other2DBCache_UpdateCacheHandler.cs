namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_UpdateCacheHandler : MessageHandler<Scene, Other2DBCache_UpdateCache>
    {
        protected override async ETTask Run(Scene scene, Other2DBCache_UpdateCache message)
        {
            Entity t = MongoHelper.Deserialize<Entity>(message.Entity);
            scene.GetComponent<DBCacheComponent>().UpdateCache(message.UnitId, t);

            await ETTask.CompletedTask;
        }
    }
}