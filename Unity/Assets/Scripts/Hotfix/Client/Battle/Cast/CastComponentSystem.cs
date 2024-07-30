namespace ET.Client
{
    [EntitySystemOf(typeof(ClientCastComponent))]
    [FriendOfAttribute(typeof(ET.Client.ClientCastComponent))]
    public static partial class CastComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ClientCastComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ClientCastComponent self)
        {
            foreach (var castsValue in self.Casts.Values)
            {
                ClientCast cast = castsValue;
                cast?.Dispose();
            }
            
            self.Casts.Clear();
        }

        public static void Add(this ClientCastComponent self, ClientCast clientCast)
        {
            self.Casts.TryAdd(clientCast.Id, clientCast);
        }

        public static ClientCast Get(this ClientCastComponent self, long id)
        {
            if (self.Casts.TryGetValue(id, out EntityRef<ClientCast> cast))
            {
                return cast;
            }

            return null;
        }

        public static void Remove(this ClientCastComponent self, long id)
        {
            ClientCast clientCast = self.Get(id);
            if (clientCast == null)
            {
                return;
            }

            self.Casts.Remove(id);
            clientCast.Dispose();
        }
    }
}