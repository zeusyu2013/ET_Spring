namespace ET.Server
{
    [MessageHandler(SceneType.DBCache)]
    public class Other2DBCache_GetUnitHandler : MessageHandler<Scene, Other2DBCache_GetUnit, DBCache2Other_GetUnit>
    {
        protected override async ETTask Run(Scene scene, Other2DBCache_GetUnit request, DBCache2Other_GetUnit response)
        {
            long unitId = request.UnitId;
            if (unitId < 1)
            {
                response.Error = ErrorCode.ERR_DBCacheUnitIdInvalid;
                response.Message = "获取玩家缓存时，玩家id无效";
                return;
            }

            Unit unit = await scene.GetComponent<DBCacheComponent>().Query<Unit>(unitId);
            if (unit == null)
            {
                response.Error = ErrorCode.ERR_DBCacheUnitNotFound;
                response.Message = $"未找到指定Unit的数据信息：{unitId}";
                return;
            }

            foreach (Entity child in unit.Children.Values)
            {
                var bytes = MongoHelper.Serialize(child);
                response.Entities.Add(bytes);
            }
        }
    }
}