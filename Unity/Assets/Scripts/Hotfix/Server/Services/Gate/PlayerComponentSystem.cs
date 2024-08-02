using System.Linq;

namespace ET.Server
{
    [FriendOf(typeof(PlayerComponent))]
    public static partial class PlayerComponentSystem
    {
        public static void Add(this PlayerComponent self, Player player)
        {
            self.dictionary.Add(player.Id, player);
        }
        
        public static void Remove(this PlayerComponent self, Player player)
        {
            self.dictionary.Remove(player.Id);
            player.Dispose();
        }
        
        public static Player GetByAccount(this PlayerComponent self,  long accountId)
        {
            self.dictionary.TryGetValue(accountId, out EntityRef<Player> player);
            return player;
        }
    }
}