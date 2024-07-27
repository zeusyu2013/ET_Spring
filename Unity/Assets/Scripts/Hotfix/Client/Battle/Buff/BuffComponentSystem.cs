namespace ET.Client
{
    [EntitySystemOf(typeof(ClientBuffComponent))]
    [FriendOfAttribute(typeof(ET.Client.ClientBuffComponent))]
    [FriendOfAttribute(typeof(ET.Client.ClientBuff))]
    public static partial class BuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientBuffComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientBuffComponent self)
        {
            foreach (var buffsValue in self.Buffs.Values)
            {
                ClientBuff clientBuff = buffsValue;
                clientBuff?.Dispose();
            }

            self.Buffs.Clear();
        }

        public static void Add(this ClientBuffComponent self, ClientBuff clientBuff)
        {
            if (self.Buffs.ContainsKey(clientBuff.Id))
            {
                return;
            }

            self.Buffs.Add(clientBuff.Id, clientBuff);
            clientBuff.Owner = self.GetParent<Unit>();
        }

        public static ClientBuff Get(this ClientBuffComponent self, long id)
        {
            if (self.Buffs.TryGetValue(id, out EntityRef<ClientBuff> buff))
            {
                return buff;
            }

            return null;
        }

        public static void Update(this ClientBuffComponent self, BuffInfo info)
        {
            ClientBuff clientBuff = self.Get(info.Id);
            if (clientBuff == null)
            {
                return;
            }

            clientBuff.CreateTime = info.CreateTime;
            clientBuff.ExpiredTime = info.ExpiredTime;
        }

        public static void Remove(this ClientBuffComponent self, long buffId)
        {
            
        }
    }
}