namespace ET.Server
{
    public static partial class UnitHelper
    {
        public static void Send2Unit(this Scene root, long unitId, IMessage message)
        {
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, message);
        }

        public static async ETTask<IResponse> Call2Unit(this Scene root, long unitId, IRequest request)
        {
            return await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(unitId, request);
        }
    }
}