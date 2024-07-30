namespace ET.Server
{
    [EntitySystemOf(typeof(CreateMonsterInfo))]
    [FriendOfAttribute(typeof(ET.Server.CreateMonsterInfo))]
    public static partial class CreateMonsterInfoSystem
    {
        [Invoke(TimerInvokeType.MonsterDeadTimer)]
        public class MonsterDead : ATimer<Unit>
        {
            protected override void Run(Unit self)
            {
                self?.Dispose();
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.CreateMonsterInfo self, int configId)
        {
            self.MonsterConfigId = configId;
        }
    }
}