namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_AddOrUpdateUnitCacheHandler : MessageHandler<Scene, Other2DBCache_AddOrUpdateUnitCache>
    {
        protected override async ETTask Run(Scene root, Other2DBCache_AddOrUpdateUnitCache message)
        {
            await root.GetComponent<DBCacheComponent>().AddOrUpdateUnitCache(message.UnitId, message.EntityTypes, message.EntityBytes);
        }
    }
}