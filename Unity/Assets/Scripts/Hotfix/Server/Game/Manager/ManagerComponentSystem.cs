namespace ET.Server
{
    [EntitySystemOf(typeof(ManagerComponent))]
    public static partial class ManagerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ManagerComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.ManagerComponent self)
        {
        }

        public static async ETTask ShutdownRequestHall(this ManagerComponent self)
        {
            Manager2Request_ShutDown request = Manager2Request_ShutDown.Create();
            Request2Manager_ShutDown response = (Request2Manager_ShutDown)await self.Root().GetComponent<ProcessInnerSender>()
                    .Call(StartSceneConfigCategory.Instance.RequestHall.ActorId, request);
            if (response.Error == ErrorCode.ERR_Success)
            {
                Log.Console("RequestHall is closed");
            }
        }
    }
}