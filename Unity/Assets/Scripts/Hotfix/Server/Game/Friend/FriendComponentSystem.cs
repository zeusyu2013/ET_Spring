using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(FriendComponent))]
    [FriendOfAttribute(typeof(ET.Server.FriendComponent))]
    [FriendOfAttribute(typeof(ET.Server.Friend))]
    public static partial class FriendComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.FriendComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.FriendComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.FriendComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                Friend friend = entity as Friend;
                self.Friends.Add(friend.Id, friend);
            }
        }

        public static List<FriendInfo> GetFriendInfos(this FriendComponent self)
        {
            List<FriendInfo> infos = new();

            foreach (Friend friendsValue in self.Friends.Values)
            {
                infos.Add(friendsValue.ToMessage());
            }

            return infos;
        }

        public static void AddFriend(this FriendComponent self, long unitId, string name)
        {
            if (self.Friends.ContainsKey(unitId))
            {
                return;
            }

            Friend friend = self.AddChildWithId<Friend>(unitId);
            friend.UnitName = name;
            self.Friends.Add(unitId, friend);
            self.AddChild(friend);
        }

        public static void DeleteFriend(this FriendComponent self, long unitId)
        {
            if (!self.Friends.ContainsKey(unitId))
            {
                return;
            }

            self.Friends.Remove(unitId);
            self.RemoveChild(unitId);
        }

        public static void IncFriendly(this FriendComponent self, long unitId, int friendly)
        {
            if (friendly < 1)
            {
                return;
            }
            
            if (!self.Friends.TryGetValue(unitId, out var friendRef))
            {
                return;
            }

            Friend friend = friendRef;
            friend.Friendly += friendly;
        }
    }
}