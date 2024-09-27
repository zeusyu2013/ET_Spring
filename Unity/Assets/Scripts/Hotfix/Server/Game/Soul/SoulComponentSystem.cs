using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(SoulComponent))]
    [FriendOfAttribute(typeof(ET.Server.Soul))]
    [FriendOfAttribute(typeof(ET.Server.SoulComponent))]
    public static partial class SoulComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.SoulComponent self)
        {
            foreach (Soul soul in self.Children.Values.Cast<Soul>())
            {
                self.AddChild(soul);

                soul.Initialization();
            }
        }

        public static void Add(this SoulComponent self, int configId)
        {
            self.AddChild<Soul, int>(configId);
        }

        public static Soul Get(this SoulComponent self, int configId)
        {
            foreach (Soul soul in self.Children.Values.Cast<Soul>())
            {
                if (soul == null)
                {
                    continue;
                }

                if (soul.ConfigId == configId)
                {
                    return soul;
                }
            }

            return null;
        }

        public static Dictionary<int, int> GetBattle(this SoulComponent self)
        {
            return self.Battles;
        }

        public static int Battle(this SoulComponent self, int battleId, int configId, int position)
        {
            Soul soul = self.Get(configId);
            if (soul == null)
            {
                return ErrorCode.ERR_SoulNotFound;
            }
            
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(soul.ConfigId, position);
            if (self.Battles.Contains(kvp))
            {
                return ErrorCode.ERR_SoulAlreadyOnBattle;
            }
            
            self.Battles.Add(configId, position);
            
            return ErrorCode.ERR_Success;
        }
    }
}