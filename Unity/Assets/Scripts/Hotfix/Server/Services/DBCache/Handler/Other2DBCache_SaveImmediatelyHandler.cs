namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_SaveImmediatelyHandler : MessageHandler<Scene, Other2DBCache_SaveImmediately>
    {
        protected override async ETTask Run(Scene root, Other2DBCache_SaveImmediately message)
        {
            await root.GetComponent<DBCacheComponent>().SaveImmediately(message.UnitId, message.EntityBytes);
        }
    }
}