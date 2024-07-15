using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(DungeonTimeComponent))]
    [FriendOfAttribute(typeof(ET.Server.DungeonTimeComponent))]
    public static partial class DungeonTimeComponentSystem
    {
        [Invoke(TimerInvokeType.DungeonTimer)]
        public class DungeonTimer : ATimer<DungeonTimeComponent>
        {
            protected override void Run(DungeonTimeComponent self)
            {
                self.Check();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.DungeonTimeComponent self, long time)
        {
            self.During = time;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.DungeonTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DungeonTimeComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        private static void Check(this DungeonTimeComponent self)
        {
            self.During -= 1000;
            if (self.During > 0)
            {
                return;
            }
            
            // todo 通知副本时间到，弹出结算与离开副本按钮
            var unit = self.Root().GetComponent<UnitComponent>().Children.FirstOrDefault();
            
            M2C_DungeonTimeout dungeonTimeout = M2C_DungeonTimeout.Create();
            MapMessageHelper.SendToClient(unit.Value as Unit, dungeonTimeout);
        }
    }
}