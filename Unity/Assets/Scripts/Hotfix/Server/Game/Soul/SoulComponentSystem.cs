using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(SoulComponent))]
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
            }
        }
    }
}