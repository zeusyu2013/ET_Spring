namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_SaveUnitHandler : MessageHandler<Scene, Other2DBCache_SaveUnit>
    {
        protected override async ETTask Run(Scene root, Other2DBCache_SaveUnit message)
        {
            Unit unit = MongoHelper.Deserialize<Unit>(message.Unit);

            UnitComponent unitComponent = root.GetComponent<UnitComponent>();
            unitComponent.AddChild(unit);
            
            foreach (byte[] bytes in message.Entities)
            {
                Entity entity = MongoHelper.Deserialize<Entity>(bytes);
                unit.AddComponent(entity);
            }
            
            await root.GetComponent<DBCacheComponent>().SaveUnit(unit);
            
            unitComponent.Remove(unit.Id);
        }
    }
}