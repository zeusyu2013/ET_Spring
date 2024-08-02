namespace ET.Server
{
    [FriendOf(typeof(GateSessionKeyComponent))]
    public static partial class GateSessionKeyComponentSystem
    {
        public static void Add(this GateSessionKeyComponent self, long key, long accountId)
        {
            self.sessionKey.Add(key, accountId);
            self.TimeoutRemoveKey(key).Coroutine();
        }

        public static long Get(this GateSessionKeyComponent self, long key)
        {
            long accountId = -1;
            self.sessionKey.TryGetValue(key, out accountId);
            return accountId;
        }

        public static void Remove(this GateSessionKeyComponent self, long key)
        {
            self.sessionKey.Remove(key);
        }

        private static async ETTask TimeoutRemoveKey(this GateSessionKeyComponent self, long key)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(20000);
            self.sessionKey.Remove(key);
        }
    }
}