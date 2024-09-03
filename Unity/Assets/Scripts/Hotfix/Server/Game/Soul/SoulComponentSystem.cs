using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(SoulComponent))]
    [FriendOfAttribute(typeof(ET.Server.Soul))]
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
    }
}