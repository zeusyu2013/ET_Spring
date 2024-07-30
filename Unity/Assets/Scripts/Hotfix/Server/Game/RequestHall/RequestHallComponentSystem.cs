using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(RequestHallComponent))]
    [FriendOfAttribute(typeof(ET.Server.GameRequest))]
    [FriendOfAttribute(typeof(ET.Server.RequestHallComponent))]
    public static partial class RequestHallComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.RequestHallComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.RequestHallComponent self)
        {
            foreach (Entity childrenValue in self.Children.Values)
            {
                GameRequest request = childrenValue as GameRequest;
                if (self.GameRequests.TryGetValue(request.UnitId, out List<EntityRef<GameRequest>> value))
                {
                    value.Add(request);
                }
                else
                {
                    self.GameRequests.Add(request.UnitId, new List<EntityRef<GameRequest>>());
                }
            }
        }

        public static void AddRequest(this RequestHallComponent self, long unitId, long senderUnitId, int requestType)
        {
            if (self.GameRequests.TryGetValue(unitId, out List<EntityRef<GameRequest>> list))
            {
                foreach (var entityRef in list)
                {
                    GameRequest tempReq = entityRef;

                    // 过滤重复请求
                    if ((int)tempReq.RequestType == requestType && tempReq.SenderUnitId == senderUnitId)
                    {
                        return;
                    }
                }
            }

            GameRequest request = self.AddChild<GameRequest>();
            request.UnitId = unitId;
            request.SenderUnitId = senderUnitId;
            request.RequestType = (GameRequestType)requestType;

            if (!self.GameRequests.TryGetValue(unitId, out List<EntityRef<GameRequest>> _))
            {
                self.GameRequests.Add(unitId, new List<EntityRef<GameRequest>>());
            }

            self.GameRequests[unitId].Add(request);
        }

        public static List<GameRequestInfo> GetRequests(this RequestHallComponent self, long unitId)
        {
            List<GameRequestInfo> infos = new();

            if (!self.GameRequests.TryGetValue(unitId, out var list))
            {
                return infos;
            }

            foreach (EntityRef<GameRequest> gameRequestRef in list)
            {
                GameRequest request = gameRequestRef;
                infos.Add(request.ToMessage());

                // 拿到所有数据后，移除请求信息
                self.RemoveChild(request.Id);
            }

            self.GameRequests.Remove(unitId);

            return infos;
        }

        public static async ETTask Save(this RequestHallComponent self)
        {
            await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(self);
        }
    }
}