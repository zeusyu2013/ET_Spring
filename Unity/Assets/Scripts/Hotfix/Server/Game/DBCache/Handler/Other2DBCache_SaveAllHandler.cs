namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_SaveAllHandler : MessageHandler<Scene, Other2DBCache_SaveAll>
    {
        protected override async ETTask Run(Scene scene, Other2DBCache_SaveAll message)
        {
            await scene.GetComponent<DBCacheComponent>().SaveAll();
        }
    }
}