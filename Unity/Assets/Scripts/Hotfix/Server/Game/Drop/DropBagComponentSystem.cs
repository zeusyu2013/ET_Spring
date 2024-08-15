using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(DropBagComponent))]
    [FriendOfAttribute(typeof(ET.Server.DropBagComponent))]
    public static partial class DropBagComponentSystem
    {
        [Invoke(TimerInvokeType.DropBagTimer)]
        public class DestroyTimer : ATimer<DropBagComponent>
        {
            protected override void Run(DropBagComponent self)
            {
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.DropBagComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DropBagComponent self)
        {
        }

        public static void Add(this DropBagComponent self, List<DropItem> items)
        {
            if (items.Count < 1)
            {
                return;
            }

            foreach (DropItem dropItem in items)
            {
                GameItemInfo info = GameItemInfo.Create();
                info.Config = dropItem.ItemConfig;
                info.Amount = dropItem.ItemAmount;
                self.GameItems.Add(info);
            }
        }

        public static List<GameItemInfo> ToMessage(this DropBagComponent self)
        {
            return self.GameItems;
        }

        public static void GetAll(this DropBagComponent self)
        {
        }

        public static void Get(this DropBagComponent self, int configId)
        {
            GameItemInfo info = self.GameItems.Find(x => x.Config == configId);
            if (info == null)
            {
                return;
            }
        }

        public static async ETTask<int> Assignment(this DropBagComponent self, long unitId, long teamId, long assignmentUnitId, int itemConfigId)
        {
            GameItemInfo info = self.GameItems.Find(x => x.Config == itemConfigId);
            if (info == null)
            {
                return ErrorCode.ERR_DropItemNotFound;
            }

            if (self.BelongUnitId != 0 && unitId != self.BelongUnitId)
            {
                return ErrorCode.ERR_DropNotBelong;
            }

            if (self.BelongTeamId != 0)
            {
                if (self.BelongTeamId != teamId)
                {
                    return ErrorCode.ERR_DropNotBelong;
                }

                StartSceneConfig teamHall = StartSceneConfigCategory.Instance.TeamHall;
                M2T_GetTeamInfo m2TGetTeamInfo = M2T_GetTeamInfo.Create();
                m2TGetTeamInfo.TeamId = teamId;
                T2M_GetTeamInfo response = (T2M_GetTeamInfo)await self.Root().GetComponent<MessageSender>().Call(teamHall.ActorId, m2TGetTeamInfo);
                TeamInfo teamInfo = response.TeamInfo;
                if (teamInfo == null)
                {
                    return ErrorCode.ERR_DropNotBelong;
                }

                if (teamInfo.TeamLeaderId != unitId)
                {
                    return ErrorCode.ERR_DropItemAssignmentNoPermission;
                }

                if (teamInfo.TeamLeaderId != assignmentUnitId && !teamInfo.TeamMemberIds.Contains(assignmentUnitId))
                {
                    return ErrorCode.ERR_DropNotBelong;
                }
            }

            UnitComponent unitComponent = self.Scene().GetComponent<UnitComponent>();
            Unit assignmentUnit = unitComponent.Get(assignmentUnitId);
            if (assignmentUnit == null)
            {
                return ErrorCode.ERR_DropItemAssignmentUnitNotFound;
            }

            BagComponent bagComponent = assignmentUnit.GetComponent<BagComponent>();
            bagComponent.AddItem(info.Config, info.Amount);

            self.GameItems.Remove(info);

            return ErrorCode.ERR_Success;
        }
    }
}