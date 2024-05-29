namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RerandomEquipmentPropertiesHandler : MessageLocationHandler<Unit, C2M_RerandomEquipmentProperties,
        M2C_RerandomEquipmentProperties>
    {
        protected override async ETTask Run(Unit unit, C2M_RerandomEquipmentProperties request, M2C_RerandomEquipmentProperties response)
        {
            EquipmentContainerComponent container = unit.GetComponent<EquipmentContainerComponent>();
            if (container == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "未找到装备容器";
                return;
            }

            GameItem item = container.GetEquipmentByConfigId(request.EquipmentConfigId);
            if (item == null)
            {
                response.Error = ErrorCode.ERR_NotFoundEquipment;
                response.Message = "没找到指定装备";
                return;
            }

            EquipmentInfoComponent infoComponent = item.GetComponent<EquipmentInfoComponent>();
            if (infoComponent == null)
            {
                response.Error = ErrorCode.ERR_NotFoundComponent;
                response.Message = "未找到道具的装备组件";
                return;
            }
            
            // todo:检查消耗
            
            infoComponent.RerandomProperties();

            response.Error = ErrorCode.ERR_Success;
            response.EquipmentRandomProperties = infoComponent.ToMessage();

            await ETTask.CompletedTask;
        }
    }
}